using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    public void StartHosting()
    {
        base.StartHost();
    }

    public void ChangeScene(string sceneName)
    {
        base.onlineScene = sceneName;
    }

    public void StartClientManualServer()
    {
        string ip = ManualServerInfo.GetIp();
        int port = ManualServerInfo.GetPort();

        Debug.Log("Connecting to " + ip + ":" + port);

        StartClient(ip, port);
    }

    public void StartClient(string ip, int port)
    {
        base.networkAddress = ip;
        base.networkPort = port;
        base.StartClient();
    }

    public void JoinGame(LanConnectionInfo connectionInfo)
	{
		StartClient(connectionInfo.ipAddress, connectionInfo.port);
	}

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client Connected to the server");
        // base.OnClientConnect(conn);
    }

}
