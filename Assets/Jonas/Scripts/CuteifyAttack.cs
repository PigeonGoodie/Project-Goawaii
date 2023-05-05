using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuteifyAttack : MonoBehaviour
{
    public GameObject cuteifyParticles;
    private ParticleSystem.EmissionModule cuteifyParticlesEmission;

    public Image manaBar;

    public float maxMana;
    private float mana;

    private Camera mainCamera;
    public Transform pivot;

    private void Start()
    {
        mainCamera = Camera.main;

        UpdateMana();

        cuteifyParticlesEmission = cuteifyParticles.GetComponent<ParticleSystem>().emission;
        cuteifyParticlesEmission.enabled = false;
    }

    void Update()
    {
        RotateAttack();

        if (Input.GetKey(KeyCode.Q))
        {
            if (mana <= 0)
            {
                cuteifyParticlesEmission.enabled = false;
                return;
            }
            cuteifyParticlesEmission.enabled = true;

            mana -= Time.deltaTime;
            UpdateMana();
        }
        else
            cuteifyParticlesEmission.enabled = false;
    }

    private void RotateAttack()
    {
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0;

        Vector3 dir = cursorPosition - pivot.position;

    }

    public void AddMana()
    {
        mana++;

        if (mana > maxMana)
            mana = maxMana;

        UpdateMana();
    }

    private void UpdateMana()
    {
        manaBar.fillAmount = mana / maxMana;
    }
}
