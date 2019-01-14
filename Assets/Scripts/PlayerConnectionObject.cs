using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawnPoint;

    void Start()
    {
        spawnPoint = GameObject.Find("LevelStart");
        
        if(!isLocalPlayer) {
            return;
        }

        CmdSpawnPlayer();
    }

    // Command the server to spawn the player unit object; this will only execute on the server
    [Command]
    void CmdSpawnPlayer()
    {
        // Instantiate the player unit object
        GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);

        short playerId = playerControllerId;
        // Propagate the unit to all clients
        NetworkServer.AddPlayerForConnection(connectionToClient, playerInstance, ++playerId);
    }
}
