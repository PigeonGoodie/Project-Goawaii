using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemies : MonoBehaviour
{
    public GameObject enemy;
    public void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Enemy")
        {
            // Instantiate(GlitterDrop);

            Destroy(enemy.gameObject);

            Debug.Log("WAAAH!");

        }
    }
}
