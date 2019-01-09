using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AttachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
            {
                player.transform.parent = transform;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
            {
                player.transform.parent = null;
            }
    }
    // Update is called once per frame
    void Update()
    {
        if(player == null)
            player = GameObject.Find("Player(Clone)");
    }
}
