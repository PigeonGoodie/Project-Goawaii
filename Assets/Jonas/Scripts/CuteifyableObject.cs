using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuteifyableObject : MonoBehaviour
{
    public GameObject oldObject;
    public GameObject newObject;

    public bool addHealth = false;

    private void Start()
    {
        oldObject.SetActive(true);
        newObject.SetActive(false);

        CuteifyManager.AddCuteifyObject(gameObject);
    }

    public void Cuteify()
    {
        GetComponent<Collider>().enabled = false;
        oldObject.SetActive(false);
        newObject.SetActive(true);

        if (addHealth)
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TakeDamage(-1, null);

        CuteifyManager.DoCuteify(gameObject);
    }
}