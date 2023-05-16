using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 2;
    public int damage = 1;

    public GameObject GlitterDrop;

    public LayerMask groundMask;
    public LayerMask playerMask;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage, transform);
        }
    }

    public void SpawnGlitter()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundMask))
            Instantiate(GlitterDrop, hit.point, transform.rotation);

    }

}
