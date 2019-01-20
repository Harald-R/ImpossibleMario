using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class LevelFinisher : MovingObject
{
    [SerializeField]
    private GameObject leaderboardEntryPrefab;
    [SerializeField]
    private GameObject leaderboardMenu;
    [SerializeField]
    private GameObject leaderboardContent;
    

    private IEnumerator WaitForSecs(int x)
    {
        yield return new WaitForSeconds(x);

        Application.LoadLevel("MainMenu");
        NetworkManager.singleton.StopHost();
    }

    void EnableLeaderboard()
    {
        try {
            leaderboardMenu.SetActive(true);

            GameObject leaderboardEntry = Instantiate(leaderboardEntryPrefab);
            leaderboardEntry.transform.SetParent(leaderboardContent.transform);
            leaderboardEntry.transform.localRotation = Quaternion.identity;
            leaderboardEntry.transform.localPosition = Vector3.zero;

            float time = Time.timeSinceLevelLoad;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            string timeString = string.Format("{0}:{1}", minutes, seconds);
            leaderboardEntry.transform.Find("BackgroundImage/Time").GetComponent<TextMeshProUGUI>().text = timeString;
        } catch(Exception e) {
            Debug.Log("Leaderboard error");
        }
    }

    void finishGame()
    {
        EnableLeaderboard();
        StartCoroutine(WaitForSecs(2));
    }

    protected override bool is_ConditionSatisfied()
    {
        return  is_collision || is_moving;
    }

    protected override void DestinationReached()
    {
        finishGame();
        enabled = false;
    }

}
