using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject enemy;

    public void Start()
    {
        
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "MeleeWeapon")
        {      
            Destroy(enemy.gameObject);

            Debug.Log("WAAAH!");

        }
    }

    
}
