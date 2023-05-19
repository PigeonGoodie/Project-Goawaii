using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageController : MonoBehaviour
{
    private List<GameObject> messages;
    private int messagePos = 0;

    public GameObject news;

    private void Awake()
    {
        messages = new List<GameObject>();

        foreach (Transform t in transform)
        {
            messages.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            DisplayNextMessage();
        }
    }

    private void DisplayNextMessage()
    {
        if (news.activeSelf)
        {
            news.SetActive(false);
            return;
        }

        if(messagePos >= messages.Count)
        {
            MessagesDone();
            return;
        }

        messages[messagePos++].SetActive(true);
    }

    private void MessagesDone()
    {
        Debug.Log("All messages done");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
