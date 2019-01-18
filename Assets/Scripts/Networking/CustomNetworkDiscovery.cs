using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery
{
    private float timeout = 5f;

    private Dictionary<LanConnectionInfo, float> lanAddresses = new Dictionary<LanConnectionInfo, float>();

    private void Awake()
    {
        base.Initialize();
        StartCoroutine(CleanupExpiredEntries());
    }

    public void StartListening()
    {
        base.StartAsClient();
    }

    public void StartBroadcast()
    {
        Debug.Log("StartBroadcast");
        //base.StopBroadcast();
        base.StartAsServer();
    }

    private IEnumerator CleanupExpiredEntries()
    {
        while(true) {
            bool changed = false;

            List<LanConnectionInfo> keys = new List<LanConnectionInfo>(lanAddresses.Keys);
            foreach(LanConnectionInfo key in keys) {
                if(lanAddresses[key] <= Time.time) {
                    lanAddresses.Remove(key);
                    changed = true;
                }
            }

            if(changed) {
                UpdateGameInfo();
            }

            yield return new WaitForSeconds(timeout);
        }
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        base.OnReceivedBroadcast(fromAddress, data);

        LanConnectionInfo connectionInfo = new LanConnectionInfo(fromAddress, data);

        if(lanAddresses.ContainsKey(connectionInfo)) {
            lanAddresses[connectionInfo] = Time.time + timeout;
        } else {
            lanAddresses.Add(connectionInfo, Time.time + timeout);
            UpdateGameInfo();
        }
    }

    private void UpdateGameInfo()
    {
        AvailableGamesList.HandleNewGameList(new List<LanConnectionInfo>(lanAddresses.Keys));
    }
}
