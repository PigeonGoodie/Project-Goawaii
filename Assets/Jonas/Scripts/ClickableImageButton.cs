using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ClickableImageButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }
}
