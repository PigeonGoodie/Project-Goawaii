using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAnim : MonoBehaviour
{
    private Animator anim;

    public float attackCD;

    private float attackTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (attackTimer > 0)
                return;

            anim.Play("PlayerAttackMelee");
            attackTimer = attackCD;
        }
    }
}
