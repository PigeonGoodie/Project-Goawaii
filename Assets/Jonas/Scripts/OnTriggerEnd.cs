using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseManager>().OpenWinScreen();
    }
}
