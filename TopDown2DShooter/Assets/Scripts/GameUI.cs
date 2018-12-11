using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText;

    public int playerScore = 0;

    private void OnEnable()
    {
        Player.onUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
    }

    private void OnDisable()
    {
        Player.onUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
        PlayerPrefs.SetInt("Score", playerScore);
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        scoreText.text = string.Format("Score: {0}", playerScore.ToString());
    }
}
