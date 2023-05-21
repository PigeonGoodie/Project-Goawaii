using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuteifyableObject : MonoBehaviour
{
    public GameObject oldObject;
    public GameObject newObject;

    public bool addHealth = false;
    public bool dontCountForGoal = false;

    private void Start()
    {
        if (oldObject != null)
            oldObject.SetActive(true);
        if (newObject != null)
            newObject.SetActive(false);

        if (!dontCountForGoal)
            CuteifyManager.AddCuteifyObject(gameObject);
    }

    public void Cuteify()
    {
        GetComponent<Collider>().enabled = false;
        if (oldObject != null)
            oldObject.SetActive(false);
        if (newObject != null)
            newObject.SetActive(true);

        if (addHealth)
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TakeDamage(-1, null);

        if (!dontCountForGoal)
            CuteifyManager.DoCuteify(gameObject);
    }
}