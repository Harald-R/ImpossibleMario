using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class PlayerInfo : NetworkBehaviour
{
    [SerializeField]
    private GameObject playerNamePrefab;

    public static string playerName = "Player";
    private TextMeshProUGUI nameText;

    private Transform nameTextTransform;
    private Transform playerTransform;

    void Start()
    {
        // Create player name object
        GameObject nameTextObject = Instantiate(playerNamePrefab);
        nameText = nameTextObject.GetComponent<TextMeshProUGUI>();
        if(isLocalPlayer) CmdChangeName(playerName);
        nameTextTransform = nameText.transform;

        // Position object in canvas, near player
        GameObject canvas = GameObject.Find("Canvas");
        playerTransform = GetComponentInParent<Transform>();
        nameTextObject.transform.SetParent(canvas.transform);
        nameTextObject.transform.localPosition = playerTransform.localPosition;
        nameTextObject.transform.localRotation = playerTransform.localRotation;
    }

    void FixedUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(playerTransform.position);
        screenPos.y += 35f;
        nameTextTransform.position = screenPos;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
        Debug.Log("Changing name to " + name);
        if(isLocalPlayer) {
            Debug.Log("ISLOCALPLAYER");
            CmdChangeName(name);
        }
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    [Command]
    void CmdChangeName(string name) {
        RpcChangName(name);
    }

    [ClientRpc]
    void RpcChangName(string name) {
        nameText.text = name;
    }
}
