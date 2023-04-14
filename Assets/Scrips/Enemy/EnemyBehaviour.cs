using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    //GameObjects
    public NavMeshAgent Enemy;
    public Transform Player;

    //movement to enemy
    public float ChaseSpeed = 0.6f;
    public float IdleSpeed = 0.3f;

    //Audio from enemy
    public AudioClip EnemyIdleSound;
    public AudioClip EnemyChaseSound;
    public AudioClip EnemyDeathSound;

    //Enemy animation
    private Animator animator;

    //Enemy Health
    public int maxHealth = 5; // The maximum health of the object
    public int currentHealth; // The current health of the object
    private int damageAmount = 1;

    public Image healthBar; // The health bar UI element
    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        //health
        currentHealth = maxHealth;
        UpdateHealthBar();
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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            {
                TakeDamage(10);
            }
        }
    }

    // Call this method to apply damage to the object
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    // Call this method to heal the object
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    // This method updates the health bar UI element
    void UpdateHealthBar()
    {
        float healthPercent = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = healthPercent;
    }

    // This method is called when the object dies
    void Die()
    {
        // Destroy the object or do something else here
        Destroy(gameObject);
    }
}
