using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public EventManager eventManager;
    public PlayerController player;
    public GameObject gameOverScreen;
    public Text scoreText;
    public Text highscoreText;
    public Text promptText;

    public void RemovePromptText()
    {
        promptText.text = "";
    }
    public void UpdateHighScoreText()
    {
        highscoreText.text = $"Highest Score: {player.highscore}";
    }
    public void UpdateScoreText()
    {
        scoreText.text = player.score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ClearHighScore()
    {
        PlayerPrefs.SetInt("High Score", 0);
        Restart();
    }
}
