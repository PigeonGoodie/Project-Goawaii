using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ShowScreen(GameObject screen)
    {
        activeScreen.SetActive(false);
        activeScreen = screen;
        activeScreen.SetActive(true);
    }

    public void OpenSurvey()
    {
        Application.OpenURL("https://forms.gle/Jnh2BP5YN9ZCufj66");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
