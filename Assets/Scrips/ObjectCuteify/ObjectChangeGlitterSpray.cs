using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeGlitterSpray : MonoBehaviour
{

    //object we want to change from (first mesh 1 then after glitter mesh 2)
    public GameObject Mesh1;
    public GameObject Mesh2;

    public Transform _cuteify;

    public void Start()
    {
        _cuteify.GetComponent<ParticleSystem>().enableEmission = false;

        Mesh2.SetActive(false);
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Glitter")
        {
            
            _cuteify.GetComponent<ParticleSystem>().enableEmission = true;

            StartCoroutine(stopCutefyEmission());

        }
    }

    IEnumerator stopCutefyEmission()
    {
        yield return new WaitForSeconds(.4f);
        _cuteify.GetComponent<ParticleSystem>().enableEmission = false;

        yield return new WaitForSeconds(.5f);
        DestroyObject();

        yield return new WaitForSeconds(.1f);
        Mesh2.SetActive(true);
    }


    private void DestroyObject()
    {  
        Destroy(Mesh1);
    }
}
