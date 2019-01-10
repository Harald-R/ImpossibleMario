using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        if(!isLocalPlayer) {
            return;
        }

        CmdSpawnPlayer();
    }

    void Update()
    {
        
    }

    // Command the server to spawn the player unit object; this will only execute on the server
    [Command]
    void CmdSpawnPlayer()
    {
        // Instantaite the player unit object
        GameObject playerInstance = Instantiate(playerPrefab);

        // Propagate the unit to all clients
        NetworkServer.SpawnWithClientAuthority(playerInstance, connectionToClient);
    }
}
