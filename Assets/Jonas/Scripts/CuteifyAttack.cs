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
    public float mana;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        UpdateMana();

        cuteifyParticlesEmission = cuteifyParticles.GetComponent<ParticleSystem>().emission;
        cuteifyParticlesEmission.enabled = false;
    }

    void Update()
    {
        // RotateAttack();

        anim.SetBool("cuteify", cuteifyParticlesEmission.enabled);

        if (Input.GetKey(KeyCode.Mouse1))
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

    //private void RotateAttack()
    //{
    //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    //    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

    //    if(groundPlane.Raycast(ray, out float planeDistance))
    //    {
    //        Vector3 cursorPos = ray.GetPoint(planeDistance);

    //        pivot.LookAt(cursorPos, Vector3.up);
    //    }
    //}

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
