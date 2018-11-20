using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool IsLevel;
    public int numberOfObjectivesLeft;

    public void StartGame()
    {
        SceneManager.LoadScene("Zombie shooter level 1");
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
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void Start()
    {
        numberOfObjectivesLeft = GameObject.FindGameObjectsWithTag("Objective").Length;
    }

    public void UpdateObjectives()
    {
        if(numberOfObjectivesLeft <= 1)
        {
            EndGame();
        } else
        {
            numberOfObjectivesLeft--;
        }
    }


}
