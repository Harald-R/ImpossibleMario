using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class AttachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameObject[] players;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Array.Exists(players, element => element == other.gameObject))
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (Array.Exists(players, element => element == other.gameObject))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
