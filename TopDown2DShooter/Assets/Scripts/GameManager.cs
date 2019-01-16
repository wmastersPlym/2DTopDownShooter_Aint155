using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ScoreObj
{
    public int highScore;
    public string highScoreName;
    public int recentScore;
}

public class GameManager : MonoBehaviour {

    public bool IsLevel;
    public int numberOfObjectivesLeft;
    public ObjectivesLeftUI uiText;
    public int currentLevel = 0;
    

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        LevelManager.currentLevel = 1;
    }

    public void SetCurrentLevel() {
        print(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {

        SceneManager.LoadScene("Game Over");

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
        print("TEST");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LevelComplete() {

        LevelManager.currentScore += GameObject.Find("Canvas").GetComponent<GameUI>().playerScore;
        SceneManager.LoadScene("Level Complete");
    }

    public void NextLevel() {
        SceneManager.LoadScene(LevelManager.levelNames[LevelManager.currentLevel]);
        LevelManager.currentLevel = LevelManager.currentLevel+1;
    }

    private void Start()
    {
        
        if(IsLevel)
        {
            numberOfObjectivesLeft = GameObject.FindGameObjectsWithTag("Objective").Length;
            UpdateObjectivesUI();
            UpdatePlayerScore();
        }
    }

    public void UpdatePlayerScore() {
        GameObject.Find("Canvas").GetComponent<GameUI>().playerScore = LevelManager.currentScore;

    }

    public void UpdateObjectives()
    {
        if(numberOfObjectivesLeft <= 1)
        {
            LevelComplete();
        } else
        {
            numberOfObjectivesLeft--;
            UpdateObjectivesUI();
        }
    }

    public void UpdateObjectivesUI()
    {
        if(uiText != null) {
            uiText.UpdateText(numberOfObjectivesLeft);

        }
    }

    public void ClearPlayerScore() {
        LevelManager.currentScore = 0;
    }


}
