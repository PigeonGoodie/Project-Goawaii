using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    private List<GameObject> messages;
    private int messagePos = 0;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextMessage();
        }
    }

    private void DisplayNextMessage()
    {
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
    }
}
