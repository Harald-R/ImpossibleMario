using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof (CharacterController2D))]
public class PlayerMovement : NetworkBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Joystick joystick;
    public JumpButton jumpButton;

    private float _move;
    private bool _crouch;
    private bool _jump;

    public override void OnStartLocalPlayer()
    {
        // Set the camera target for our local player
        Camera.main.GetComponent<CameraFollow>().SetTarget(this.GetComponentInParent<Transform>());
    }

    void Update()
    {
        // Check if the player has authority over this game object, i.e. handling its local object
        Debug.Log(hasAuthority + " " + isLocalPlayer);
        if(isLocalPlayer) {
#if UNITY_STANDALONE || UNITY_EDITOR
                _move = Input.GetAxisRaw("Horizontal") * runSpeed;
                if(Input.GetButtonDown("Jump")) {
                    _jump = true;
                } 
            
                if(Input.GetButton("Crouch") && !_jump) {
                    _crouch = true;
                } else {
                    _crouch = false;
                }
                    
#elif UNITY_ANDROID
                if(Mathf.Abs(joystick.Horizontal) < .2f) {
                    _move = 0f;
                } else if(Mathf.Abs(joystick.Horizontal) < .5f) {
                    _move = Mathf.Sign(joystick.Horizontal) * ScaleToRange(Mathf.Abs(joystick.Horizontal), .2f, .5f, runSpeed * .5f, runSpeed);
                } else {
                    _move = Mathf.Sign(joystick.Horizontal) * runSpeed;
                }

                if(jumpButton.isPressed) {
                    _jump = true;
                }
#endif
        }

        // Send the new state of the model to the server
        CmdMove(transform.position, _move, _crouch, _jump);
    }

    void FixedUpdate()
    {
        if(!hasAuthority) {
            return;
        }

        // Move the character for the local player
        controller.Move(_move * Time.fixedDeltaTime, _crouch, _jump);

        
        _jump = false;
    }

    float ScaleToRange(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    [Command]
    void CmdMove(Vector3 position, float move, bool crouch, bool jump)
    {
        // Update the model state for all clients
        RpcMove(position, move, crouch, jump);
    }

    [ClientRpc]
    void RpcMove(Vector3 position, float move, bool crouch, bool jump)
    {
        // Do not update the model for the local player
        if(hasAuthority) {
            return;
        }

        // Interpolate between the current and target positions
        transform.position = Vector3.Lerp(transform.position, position, .5f);

        // Update the state varaibles for the rest of the clients
        _move = move;
        _crouch = crouch;
        _jump = jump;

        // Change the model position for the rest of the clients
        
        controller.Move(move * Time.fixedDeltaTime, crouch, jump);
        
        _jump = false;
    }
}
