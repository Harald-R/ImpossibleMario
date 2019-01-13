using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CustomLobbyManager : NetworkLobbyManager
{
    public void Awake()
    {
        string sceneName = SceneManagerWithParameters.GetParam("SceneName");
        base.playScene = sceneName;
    }

    public override void OnLobbyClientEnter()
    {
        Debug.Log("Client joined the game");
    }
}
