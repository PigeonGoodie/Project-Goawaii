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
        if (collide.CompareTag("MeleeWeapon"))
        {
            health--;

            if (health > 0)
                return;

            SpawnGlitter();
            Destroy(gameObject);
        }
    }

    public void SpawnGlitter()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundMask))
            Instantiate(GlitterDrop, hit.point, transform.rotation);

    }

}
