using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar (hook = "OnChangeHealth")] public int currentHealth = maxHealth;

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
}
