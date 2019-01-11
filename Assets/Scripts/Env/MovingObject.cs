using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
	public GameObject player;
	public float dir_x;
	public float dir_y;
	protected bool is_collision;
	float new_y;
	float new_x;
	float step;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)
            {           
            	is_collision=true;
                player.transform.SetParent(transform);
            }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject == player)
            {
               is_collision=false;               
               player.transform.SetParent(null);
            }
    }

    void Start()
    {    	
    	step = speed * Time.deltaTime;
    	new_x = transform.position.x + dir_x;
        new_y = transform.position.y + dir_y;
    }

    protected bool isDestReached()
    {
    	return (new_x == transform.position.x) && (new_y == transform.position.y);
    }

    protected void moveObject()
    {
    	transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x, new_y , transform.position.z), step);          		
    }

    void Update()
    {       
        if (player == null)
        {
            if(GameObject.FindGameObjectsWithTag("Player").Length > 0)
                player = GameObject.FindGameObjectsWithTag("Player")[0];
        }

        if(is_collision)
        {        	
        	moveObject();
        }
    }
 }
