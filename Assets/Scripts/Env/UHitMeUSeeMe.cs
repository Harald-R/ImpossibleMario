using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UHitMeUSeeMe : MonoBehaviour
{

	public GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)
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
        if (player == null)
        {
            if(GameObject.FindGameObjectsWithTag("Player").Length > 0)
                player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
            
    }
}
