using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealing : MonoBehaviour
{
    public int Damage = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I dealt damage");
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if(health != null)
        {
            health.TakeDamage(Damage);
        }
    }

}
