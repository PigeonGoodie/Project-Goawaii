using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryGlitter : MonoBehaviour
{
    public int NumberOfGlitterDrop { get; private set; }

    public void GlitterDropCollected()
    {
        NumberOfGlitterDrop++;
    }
}
