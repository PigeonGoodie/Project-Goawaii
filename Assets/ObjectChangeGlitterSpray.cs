using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeGlitterSpray : MonoBehaviour
{

    //object we want to change from (first mesh 1 then after glitter mesh 2)
    public GameObject Mesh1;
    public GameObject Mesh2;

    //reference to projectile
 // public Rigidbody Glitter


    public void Start()
    {
      //Glitter = GetComponent<Rigidbody>();

        Mesh2.SetActive(false);
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Glitter")
        {
            Mesh2.SetActive(true);

            Destroy(Mesh1);

            Debug.Log("swap");

        }
    }
}
