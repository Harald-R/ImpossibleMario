using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private bool is_multiplayerGame;

    void Start()
    {
        gameOver = false;
        restart = false;
        is_multiplayerGame = false;
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}