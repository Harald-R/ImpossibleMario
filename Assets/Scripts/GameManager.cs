using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject waitingMenu;

    public void Awake()
    {
        if(pauseMenu == null) {
            pauseMenu = GameObject.Find("PauseMenu");
        }
        if(waitingMenu == null) {
            waitingMenu = GameObject.Find("WaitingForPlayersMenu");
        }

        PauseMenu.IsOn = false;
    }

    public void TogglePauseMenu()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }

    public void SetWaitingMenuState(bool state)
    {
        waitingMenu.gameObject.SetActive(state);

        // Set bool as true if needed to ensure that player has no control over character
        PauseMenu.IsOn = state;
    }

    private IEnumerator WaitForPlayersLoop()
    {
        WaitForSeconds waitTime = new WaitForSeconds(2);
        while(true) {
            if(NetworkManager.singleton.numPlayers >= Globals.GlobalValues.NUM_PLAYERS) {
                break;
            }
            yield return waitTime;
        }
        SetWaitingMenuState(false);
    }

    public void WaitForPlayers()
    {
        if(NetworkManager.singleton.numPlayers < Globals.GlobalValues.NUM_PLAYERS) {
            SetWaitingMenuState(true);
        }

        StartCoroutine(WaitForPlayersLoop());
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        NetworkManager.singleton.StopHost();
    }
}
