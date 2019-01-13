using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    public GameObject spawnPoint = null;

    void Awake()
    {
        StartHost();
        Debug.Log("Awake");
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("OnServerAddPlayer");
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        GameObject player = (GameObject)Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("OnClientConnet");
        ClientScene.AddPlayer(conn, 0);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("OnClientDisconnect");
        base.OnClientDisconnect(conn);
    }
    public override void OnStopHost()
    {
        Debug.Log("OnStopHost");
        spawnPoint = null;
        base.OnStopHost();
    }

}