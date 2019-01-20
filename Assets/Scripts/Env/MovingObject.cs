using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingObject : MonoBehaviour, IEventSubject
{
    public float speed;
    protected GameObject[] players;
    public float dir_x;
	public float dir_y;
    private float start_x;
    private float start_y;
	protected bool is_collision;
    protected bool is_moving = false;
	float new_y;
	float new_x;
	float step;

    public GameObject[] eventTriggers;
    protected bool state = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(Array.Exists(players, element => element == other.gameObject))
        {           
            is_collision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (Array.Exists(players, element => element == other.gameObject))
        {
            is_collision = false;
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(start_x, start_y,0);
        enabled = true;
    }

    void Start()
    {    	
    	step = speed * Time.deltaTime;
        start_x = transform.position.x;
        start_y = transform.position.y;
        new_x = transform.position.x + dir_x;
        new_y = transform.position.y + dir_y;
    }

    protected bool is_DestReached()
    {
    	return (Mathf.Abs(new_x-transform.position.x) < 0.0001f) && (Mathf.Abs(new_y - transform.position.y) < 0.0001f);
    }

    protected void moveObject()
    {
        // Debug.Log("moving");
        is_moving = true;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x, new_y , transform.position.z), step);          		
    }

    protected virtual bool is_ConditionSatisfied()
    {
        return is_collision || is_moving;
    }

    protected virtual void DestinationReached()
    {
        state = true;
        Notify();
        
        is_moving = false;
        enabled = false;
    }

    void Update()
    {       
        players = GameObject.FindGameObjectsWithTag("Player");

        if(is_ConditionSatisfied())
        {        	
        	moveObject();
        }

        if(is_DestReached())
        {
            DestinationReached();
        }
    }

    public void Notify()
    {
        foreach (GameObject eventTrigger in eventTriggers)
        {
            Debug.Log("Reached" + GetState());
            eventTrigger.GetComponent<IEventTrigger>().NotifyChange();
        }
    }

    public bool GetState()
    {
        return state;
    }
}
