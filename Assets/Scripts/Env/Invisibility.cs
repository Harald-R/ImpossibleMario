using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    void Start()
    {
    	StartCoroutine(NowYouSeeMeNowYouDont());
    }
    IEnumerator NowYouSeeMeNowYouDont()
    {
    	while(true){
    	yield return new WaitForSeconds(2);
    	if(this.gameObject.GetComponent<Renderer>().enabled )
        	this.gameObject.GetComponent<Renderer>().enabled = false;
        else
        	this.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
