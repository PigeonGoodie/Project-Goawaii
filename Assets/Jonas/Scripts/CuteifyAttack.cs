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

    private void Start()
    {
        UpdateMana();

        cuteifyParticlesEmission = cuteifyParticles.GetComponent<ParticleSystem>().emission;
        cuteifyParticlesEmission.enabled = false;
    }

    void Update()
    {
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
