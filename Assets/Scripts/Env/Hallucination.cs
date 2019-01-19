using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Hallucination : MonoBehaviour, IEventSubject
{
    protected GameObject[] players;
    public GameObject[] eventTriggers;
    public float DissapearTime = 1f;
    private bool state = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Array.Exists(players, element => element == other.gameObject))
        {
            StartCoroutine(WaitForSecsAndDestroy(DissapearTime));
        }
    }

    IEnumerator WaitForSecsAndDestroy(float seconds){    	
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        state = true;
        Notify();
    }

    public void Notify()
    {
        foreach (GameObject eventTrigger in eventTriggers)
        {
            eventTrigger.GetComponent<IEventTrigger>().NotifyChange();
        }
    }

    public bool GetState()
    {
        return state;
    }


    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
 