using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableColliderEvent : MonoBehaviour, IEventTrigger 
{
    private int eventCounter;
    private bool triggerEventFlag = true;
    public GameObject[] Subjects;

    public void TriggerEvent()
    {
        Debug.Log("EnableColider");
        transform.GetComponent<BoxCollider2D>().enabled = triggerEventFlag;
    }
    
    public void NotifyChange()
    {
        Debug.Log("NotifyChange");
        foreach (GameObject subject in Subjects)
        {
            triggerEventFlag = triggerEventFlag & subject.GetComponent<IEventSubject>().GetState();
            Debug.Log(subject.GetComponent<IEventSubject>().GetState());
        }

        if (triggerEventFlag)
            TriggerEvent();

        triggerEventFlag = true;
    }
}
