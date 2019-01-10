using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AttachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)
            {
                player.transform.SetParent(transform);
            }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject == player)
            {
                player.transform.SetParent(null);
            }
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            if(GameObject.FindGameObjectsWithTag("Player").Length > 0)
                player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
            
    }
}
