using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxChange : MonoBehaviour
{
    public GameObject oldObject;
    public GameObject newObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        Change();
    }

    private void Start()
    {
        oldObject.SetActive(true);
        newObject.SetActive(false);
    }

    public void Change()
    {
        GetComponent<Collider>().enabled = false;
        oldObject.SetActive(false);
        newObject.SetActive(true);
    }
}