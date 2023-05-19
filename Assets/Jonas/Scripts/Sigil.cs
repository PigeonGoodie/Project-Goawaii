using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigil : MonoBehaviour
{
    public GameObject oldObject;
    public GameObject newObject;

    private void Start()
    {
        oldObject.SetActive(true);
        newObject.SetActive(false);  
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            GetComponent<Collider>().enabled = false;
            oldObject.SetActive(false);
            newObject.SetActive(true);

            Debug.Log("Success!");
        }
    }


}