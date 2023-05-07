using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string GameScene;

    public GameObject activeScreen;

    public GameObject escScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowScreen(escScreen);
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(GameScene, LoadSceneMode.Single);
    }

    public void ShowScreen(GameObject screen)
    {
        activeScreen.SetActive(false);
        activeScreen = screen;
        activeScreen.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
