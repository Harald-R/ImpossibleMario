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
    }

    public void TogglePauseMenu()
    {        
        if(pauseMenu.gameObject.activeInHierarchy) {
            pauseMenu.gameObject.SetActive(false);
            // Time.timeScale = 1f;
        } else {
            pauseMenu.gameObject.SetActive(true);
            // Time.timeScale = 0f;
        }
    }

    public void ReturnToMainMenu()
    {
        // TODO: Do the server disconnect logic
        SceneManager.LoadScene("MainMenu");
        NetworkManager.singleton.StopHost();
    }
}
