using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UHitMeUSeeMe : MonoBehaviour
{

    protected GameObject[] players;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Array.Exists(players, element => element == other.gameObject))
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    void Start()
    {
    	this.gameObject.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
