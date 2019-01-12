using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class AvailableGamesList
{
    public static event Action<List<LanConnectionInfo>> OnAvailableGamesChanged = delegate { };

    private static List<LanConnectionInfo> connections = new List<LanConnectionInfo>();

    public static void HandleNewGameList(List<LanConnectionInfo> connectionInfos)
    {
        connections = connectionInfos;
        OnAvailableGamesChanged(connectionInfos);
    }
}