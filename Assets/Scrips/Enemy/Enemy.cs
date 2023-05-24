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

    public List<AudioClip> damageAudio;
    public List<AudioClip> deathAudio;

    private Animator animator;
    private AudioSource audioSource;
    private AudioSource deathAudioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        deathAudioSource = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.CompareTag("MeleeWeapon"))
        {
            health--;
            animator.SetTrigger("damage");

            if (health > 0)
            {
                audioSource.clip = damageAudio[Random.Range(0, damageAudio.Count)];
                audioSource.Play();
                return;
            }

            deathAudioSource.clip = deathAudio[Random.Range(0, deathAudio.Count)];
            deathAudioSource.Play();

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
