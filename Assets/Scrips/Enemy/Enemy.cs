using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 2;

    public GameObject GlitterDrop;

    public LayerMask groundMask;

    public void OnTriggerEnter(Collider collide)
    {
        Debug.Log("Hit");

        if (collide.CompareTag("MeleeWeapon"))
        {
            // Instantiate(GlitterDrop);

            health--;

            if (health > 0)
                return;

            SpawnGlitter();
            Destroy(gameObject);

            Debug.Log("WAAAH!");
        }
    }

    public void SpawnGlitter()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundMask))
            Instantiate(GlitterDrop, hit.point, transform.rotation);

    }

}
