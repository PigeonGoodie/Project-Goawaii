using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeGlitterSpray : MonoBehaviour
{

    //object we want to change from (first mesh 1 then after glitter mesh 2)
    public GameObject oldObject;
    public GameObject newObject;

    public Transform cuteifyParticles;

    public void Start()
    {
        cuteifyParticles.GetComponent<ParticleSystem>().enableEmission = false;

        newObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Glitter")
        {
            
            cuteifyParticles.GetComponent<ParticleSystem>().enableEmission = true;

            StartCoroutine(stopCutefyEmission());

        }
    }

    IEnumerator stopCutefyEmission()
    {
        yield return new WaitForSeconds(.4f);
        cuteifyParticles.GetComponent<ParticleSystem>().enableEmission = false;

        yield return new WaitForSeconds(.5f);
        DestroyObject();

        yield return new WaitForSeconds(.1f);
        newObject.SetActive(true);
    }


    private void DestroyObject()
    {  
        Destroy(oldObject);
    }
}
