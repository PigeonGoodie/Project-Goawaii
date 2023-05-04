using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeGlitterSpray : MonoBehaviour
{

    //object we want to change from (first mesh 1 then after glitter mesh 2)
    public GameObject oldObject;
    public GameObject newObject;

    public Transform cuteifyParticles;
    private ParticleSystem.EmissionModule cuteifyParticlesEmission;

    public void Start()
    {
        cuteifyParticlesEmission = cuteifyParticles.GetComponent<ParticleSystem>().emission;
        cuteifyParticlesEmission.enabled = false;

        newObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.CompareTag("Glitter"))
        {
            StartCoroutine(StopCutefyEmission());
        }
    }

    IEnumerator StopCutefyEmission()
    {
        cuteifyParticlesEmission.enabled = true;
        yield return new WaitForSeconds(.4f);
        cuteifyParticlesEmission.enabled = false;

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
