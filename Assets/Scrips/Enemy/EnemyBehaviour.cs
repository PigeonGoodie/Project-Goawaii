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
    public float ChaseSpeed = 2f;

    public float detectionRange = 10;

    private bool doChase = false;

    //Audio from enemy
    public AudioClip EnemyIdleSound;
    public AudioClip EnemyChaseSound;
    public AudioClip EnemyDeathSound;

    //Enemy animation
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (doChase && Vector3.Distance(transform.position, Player.position) > detectionRange)
        {
            doChase = false;
            Enemy.speed = 0;
            animator.SetBool("doRun", doChase);
        }
        else if (!doChase && Vector3.Distance(transform.position, Player.position) < detectionRange)
        {
            doChase = true;
            Enemy.speed = ChaseSpeed;
            animator.SetBool("doRun", doChase);
        }

        if (doChase)
            Enemy.SetDestination(Player.position);
    }
}
