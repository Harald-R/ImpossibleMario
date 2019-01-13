using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    public GameObject spawnPoint;
    [SyncVar (hook = "OnChangeHealth")] public int currentHealth = maxHealth;

    public void Awake()
    {
        spawnPoint = GameObject.Find("LevelStart");
    }

    public void TakeDamage(int ammount)
    {
        if(!isServer)
        {
            return;
        }

        currentHealth -= ammount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    void OnChangeHealth(int health)
    {
        Debug.Log("Took Damage");
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            transform.position = spawnPoint.transform.position;
        }
    }
}
