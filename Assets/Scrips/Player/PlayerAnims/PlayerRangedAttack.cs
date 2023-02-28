using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform project;
    public float projectileSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, project.position, project.rotation) as Rigidbody;
            projectileInstance.AddForce(project.forward * projectileSpeed);

            Debug.Log("SHOOT");
        }
    }
}
