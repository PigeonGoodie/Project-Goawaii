using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(Player.position);
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "MeleeWeapon")
        {
            // Instantiate(GlitterDrop);

            Destroy(Enemy.gameObject);

            Debug.Log("WAAAH!");

        }
    }
}
