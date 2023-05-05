using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public List<CharmObject> charms;

    public void UpdateHealth(int health)
    {
        health--;
        int i = -1;

        foreach (CharmObject c in charms)
        {
            i++;
            if (i <= health)
                SetCharm(i, true);
            else
                SetCharm(i, false);
        }
    }

    private void SetCharm(int charmPos, bool active)
    {
        charms[charmPos].full.SetActive(active);
        charms[charmPos].broken.SetActive(!active);
    }
}

[Serializable]
public struct CharmObject
{
    public GameObject full;
    public GameObject broken;
}
