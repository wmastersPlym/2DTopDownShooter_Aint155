using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public int highscore;
    public int playerScore;
    public Text highScoreText;
    public Text playerScoreText;

    // Use this for initialization
    void Start () {
	    if(PlayerPrefs.HasKey("Highscore")) {
            highscore = PlayerPrefs.GetInt("Highscore");
        } else {
            highscore = 0;
        }
        playerScore = LevelManager.currentScore;

        if(playerScore>highscore) {
            highscore = playerScore;
            PlayerPrefs.SetInt("Highscore", playerScore);
        }

        UpdateUI();

	}

    void UpdateUI() {
        if(highScoreText != null) {
            highScoreText.text = "Highscore: " + highscore;
        }
        playerScoreText.text = "Your score: " + playerScore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
