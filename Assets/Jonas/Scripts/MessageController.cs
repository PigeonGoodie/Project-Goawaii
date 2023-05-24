using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageController : MonoBehaviour
{
    private List<GameObject> messages;
    private int messagePos = 0;

    public GameObject news;
    public GameObject notification;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
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
        if (news != null && news.activeSelf)
        {
            audioSource.Play();
            news.SetActive(false);
            return;
        }

        if (notification != null && notification.activeSelf)
        {
            notification.SetActive(false);
            return;
        }

        if (messagePos >= messages.Count && SceneManager.GetActiveScene().buildIndex != 2)
        {
            MessagesDone();
            return;
        }

        if (messagePos >= messages.Count) return;

        messages[messagePos++].SetActive(true);
    }

    private void MessagesDone()
    {
        Debug.Log("All messages done");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
