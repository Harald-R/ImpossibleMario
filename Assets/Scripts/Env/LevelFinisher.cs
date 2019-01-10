using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject player;
	public Transform[] Waypoints;
    public float speed = 2;
 
    public int CurrentPoint = 0;


	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject == player)
        	{
        	    Application.LoadLevel("MainMenu");
        	}
    }	

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
            player = GameObject.Find("Player(Clone)");

        // if(transform.position.y != Waypoints[CurrentPoint].transform.position.y)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
        // }
 
        // if(transform.position.y == Waypoints[CurrentPoint].transform.position.y)
        // {
        //     CurrentPoint +=1;
        // }
        // if( CurrentPoint >= Waypoints.Length)
        // {
        //     CurrentPoint = 0; 
        // }
    }
}
