using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelFinisher : MovingObject
{
    private IEnumerator WaitForSecs(int x)
    {
        yield return new WaitForSeconds(x);        
    }

    void finishGame()
    {
        WaitForSecs(2);
        Application.LoadLevel("MainMenu");
        NetworkManager.singleton.StopHost();
    }

    protected override bool is_ConditionSatisfied()
    {
        return ((Input.GetKeyDown(KeyCode.C)) && is_collision) || is_moving;
    }

    protected override void DestinationReached()
    {
        finishGame();
        enabled = false;
    }

}
