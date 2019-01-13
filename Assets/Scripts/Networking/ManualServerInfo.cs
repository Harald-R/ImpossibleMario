using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualServerInfo : MonoBehaviour
{
    public static string GetIp()
    {
        string ip = "localhost";
        try {
            string ipField = GameObject.Find("IPInputField").transform.Find("Text").GetComponent<Text>().text;
            
            if(ipField != "") {
                ip = ipField;
            }
        } catch(Exception e) {
            Debug.LogError(e);
        }

        return ip;
    }

    public static int GetPort()
    {
        int port = 7777;
        try {
            string portField = GameObject.Find("PortInputField").transform.Find("Text").GetComponent<Text>().text;
            
            if(portField != "") {
                port = Convert.ToInt32(portField);
            }
        } catch(Exception e) {
            Debug.LogError(e);
        }
        
        return port;
    }
}
