using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int difficultySetting;
    public GameObject pauseMenu;
    public bool GameIsPaused = false;

    [SerializeField]
    public static int[] gameDifficulty = { 2, 5, 10, 15, 20 };
    [SerializeField]

    public TMP_Text scoreText;
    public static int score;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "Game")
            {
                if (GameIsPaused)
                {
                    ResumeScene();
                } else
                {
                    PauseScene();
                }

            }
        }

        scoreText.GetComponent<TMP_Text>().text = "Score: " + score + " / " + GameManager.gameDifficulty[GameManager.difficultySetting].ToString();

        if (score == GameManager.gameDifficulty[GameManager.difficultySetting])
        {
            NextScene();
        }
    }

    public void PauseScene()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void ResumeScene()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    } 

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        score = 0;
    }

    public void QuitScene()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }
}

