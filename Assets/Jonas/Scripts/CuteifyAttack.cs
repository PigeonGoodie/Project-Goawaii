using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuteifyAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPos;
    public float projectileSpeed;

    public Image manaBar;

    public float maxMana;
    private float mana;

    private void Start()
    {
        UpdateMana();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (mana <= 0) return;

            mana -= Time.deltaTime;
            UpdateMana();

            GameObject projectileInstance;
            projectileInstance = Instantiate(projectile, spawnPos.position, spawnPos.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(spawnPos.forward * projectileSpeed);
        }
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
