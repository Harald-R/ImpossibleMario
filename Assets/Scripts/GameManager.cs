using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Awake()
    {
        if(pauseMenu == null) {
            pauseMenu = GameObject.Find("PauseMenu");
        }

        PauseMenu.IsOn = false;
    }

    public void TogglePauseMenu()
    {
        if(pauseMenu.gameObject.activeInHierarchy) {
            pauseMenu.gameObject.SetActive(false);
        } else {
            pauseMenu.gameObject.SetActive(true);
        }
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        NetworkManager.singleton.StopHost();
    }
}
