using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Hallucination : MonoBehaviour 
{
 
 	public GameObject player;
	private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)
            {
                WaitForSecs(3);
        		gameObject.SetActive(false);
            }
    }

 
    IEnumerator WaitForSecs (int seconds){    	
        yield return new WaitForSeconds(seconds);
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
 