using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Globals;

public class GameTypes : MonoBehaviour
{
    
    public GameType gameType;

    void Start()
    {
        gameType = GameType.NONE;
    }

    public GameType GetGameType()
    {
        return gameType;
    }

    public void ResetGameType()
    {
        gameType = GameType.NONE;
    }

    public void SetSingleplayer()
    {
        gameType = GameType.SINGLEPLAYER;
    }

    public void SetMultplayerHost()
    {
        gameType = GameType.MULTIPLAYER_HOST;
    }

    public void SetMultplayerClient()
    {
        gameType = GameType.MULTIPLAYER_CLIENT;
    }
}
