using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[RequireComponent(typeof(DeathSound))]
public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    public GameObject spawnPoint;
    private DeathSound deathSound;
    [SerializeField] private Animator _animator;
    [SyncVar (hook = "OnChangeHealth")] public int currentHealth = maxHealth;

    private IEnumerator StartRespawnTime(float x)
    {
        yield return new WaitForSeconds(x);
        transform.position = spawnPoint.transform.position;
        _animator.SetBool("is_dead", false);

    }

    public void Awake()
    {
        spawnPoint = GameObject.Find("LevelStart");
        deathSound = GetComponent<DeathSound>();
    }

    public void TakeDamage(int ammount)
    {
        if(!isServer)
        {
            return;
        }

        if (currentHealth > 0)
        {
            currentHealth -= ammount;
            if (currentHealth <= 0)
            {
                currentHealth = maxHealth;
                _animator.SetBool("is_dead", true);
                RpcRespawn();
            }
        }
    }

    void OnChangeHealth(int health)
    {
        //Debug.Log("Took Damage");
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            if(deathSound)
                deathSound.PlaySound();
            StartCoroutine(StartRespawnTime(0.17F));
        }
    }
}
