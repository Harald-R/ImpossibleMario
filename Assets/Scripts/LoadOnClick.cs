using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class LoadOnClick : MonoBehaviour
{
    private NetworkDiscovery serverNetwork;

    public void LoadScene (int level)
	{
		SceneManager.LoadScene(level);
        NetworkManager.singleton.networkAddress = "localhost";
        NetworkManager.singleton.networkPort = 7777;
        NetworkManager.singleton.StartHost();
        serverNetwork = gameObject.AddComponent<NetworkDiscovery>();
        serverNetwork.Initialize();
        serverNetwork.StartAsServer();
    }
}
