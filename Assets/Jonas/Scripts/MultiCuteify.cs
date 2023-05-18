using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCuteify : MonoBehaviour
{
    public List<CuteifyableObject> cuteifyObjects;

    private bool done = false;

    public GameObject oldObject;
    public GameObject newObject;

    private void Start()
    {
        oldObject.SetActive(true);
        newObject.SetActive(false);
    }

    private void Update()
    {
        if (done) return;

        foreach(CuteifyableObject c in cuteifyObjects)
        {
            if (c.oldObject.activeSelf) return;
        }

        oldObject.SetActive(false);
        newObject.SetActive(true);
        done = true;
    }
}
