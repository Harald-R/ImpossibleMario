using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ProximityObject : MovingObject
{
    private float Distance = -1;
    public float TriggerDistance = 0;

    protected override bool is_ConditionSatisfied()
    {
        if (players.Length == 0)
            return is_moving;

        if (Distance == -1)
        {
            Distance = Vector3.Distance(transform.position, players[0].transform.position);
            if (Distance < TriggerDistance) return true;
        }

        // Debug.Log(Distance);
        foreach (GameObject player in players)
        {
            Distance = Vector3.Distance(transform.position, player.transform.position);
            if (Distance < TriggerDistance)
                return true;
        }
        return is_moving;
    }

}
