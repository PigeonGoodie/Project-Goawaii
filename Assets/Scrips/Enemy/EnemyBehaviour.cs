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
    public int lives = 2;

    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
       // animator = GetComponent<Animator>();
    }
    void Start()
    {
        //health
      
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(Player.position);
    }

}
