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
    }

    void Update()
    {
        if(spawnPoint == null)
            spawnPoint = GameObject.Find("LevelStart");
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

}