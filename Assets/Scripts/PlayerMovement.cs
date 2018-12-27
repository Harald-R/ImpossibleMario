using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Joystick joystick;
    public JumpButton jumpButton;

    private float horizontalMove = 0f;
    private bool jump = false;

    void Update()
    {
    #if UNITY_STANDALONE // || UNITY_EDITOR
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump")) {
            jump = true;
        }
    #elif UNITY_ANDROID
        if(Mathf.Abs(joystick.Horizontal) < .2f) {
            horizontalMove = 0f;
        } else if(Mathf.Abs(joystick.Horizontal) < .5f) {
            horizontalMove = Mathf.Sign(joystick.Horizontal) * ScaleToRange(Mathf.Abs(joystick.Horizontal), .2f, .5f, runSpeed * .5f, runSpeed);
        } else {
            horizontalMove = Mathf.Sign(joystick.Horizontal) * runSpeed;
        }

        if(jumpButton.isPressed) {
            jump = true;
        }
    #endif
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }

    float ScaleToRange(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
