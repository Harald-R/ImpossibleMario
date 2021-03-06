﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Globals;

public class SceneLoadHandler : MonoBehaviour
{
    public GameManager gameManager = null;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void Start()
    {
        if(gameManager == null) {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        CustomNetworkDiscovery networkDiscovery = GameObject.Find("NetworkManager").GetComponent<CustomNetworkDiscovery>();

        // Get the game type as an enum
        string gameTypeStr = SceneManagerWithParameters.GetParam("GameType");
        GameType gameType;
        Enum.TryParse(gameTypeStr, out gameType);

        switch(gameType)
        {
            case Globals.GameType.NONE:
                Debug.Log("Error: GameType is NONE");
                break;
            case Globals.GameType.MULTIPLAYER_HOST:
                networkDiscovery.StartBroadcast();
                gameManager.gameObject.SetActive(true);
                gameManager.WaitForPlayers();
                break;
            default:
                break;
        }
    }
}
