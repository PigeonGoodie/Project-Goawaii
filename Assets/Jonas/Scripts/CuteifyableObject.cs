using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuteifyableObject : MonoBehaviour
{
    public GameObject oldObject;
    public GameObject newObject;

    private void Start()
    {
        oldObject.SetActive(true);
        newObject.SetActive(false);
    }

    public void Cuteify()
    {
        GetComponent<Collider>().enabled = false;
        oldObject.SetActive(false);
        newObject.SetActive(true);
    }
}