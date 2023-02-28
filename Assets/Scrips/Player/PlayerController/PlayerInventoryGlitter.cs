using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventoryGlitter : MonoBehaviour
{
    public int NumberOfGlitterDrop { get; private set; }

    public UnityEvent<PlayerInventoryGlitter> OnGlitterDropCollected;

    public void GlitterDropCollected()
    {
        NumberOfGlitterDrop++;
        OnGlitterDropCollected.Invoke(this);
    }
}
