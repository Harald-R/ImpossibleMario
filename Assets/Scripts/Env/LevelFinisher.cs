using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelFinisher : MovingObject
{
    bool conditions;
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

    void Update()
    {
        conditions = conditions || ((Input.GetKeyDown(KeyCode.C)) && is_collision);
        if (player == null)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
                player = GameObject.FindGameObjectsWithTag("Player")[0];
        }

        if (conditions)
        {
            moveObject();           
        }

        if(isDestReached())
        {
            finishGame();
        }
    }
}
