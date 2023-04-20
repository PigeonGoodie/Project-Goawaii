using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemies : MonoBehaviour
{

    private EnemyBehaviour enemyScript;

    public int lives = 2;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

            lives--;

            if (lives == 0)
            {
                Destroy(other.gameObject);
            }

            Debug.Log("WAAAH!");

        }
    }

    

}
