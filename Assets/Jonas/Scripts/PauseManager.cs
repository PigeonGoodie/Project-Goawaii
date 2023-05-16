using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject deathScreen;
    public GameObject winScreen;

    private bool paused;

    private void Awake()
    {
        Time.timeScale= 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }

    public void BackToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    private void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            paused = true;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        paused = false;
    }

    public void OpenDeathScreen()
    {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }

    public void OpenWinScreen()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }
}