using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitterDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<CuteifyAttack>().AddMana();
        Destroy(gameObject);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitterDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventoryGlitter playerInventory = other.GetComponent<PlayerInventoryGlitter>();

        if (playerInventory != null)
        {
            playerInventory.GlitterDropCollected();
            gameObject.SetActive(false);

            Debug.Log("im collected");
        }
    }
}
*/