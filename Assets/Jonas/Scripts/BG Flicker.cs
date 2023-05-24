using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFlicker : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public float swapInterval = 1;

    private void Start()
    {
        StartCoroutine(SwapObjectsRoutine());
    }

    private System.Collections.IEnumerator SwapObjectsRoutine()
    {
        while (true)
        {
            objectA.SetActive(true);
            objectB.SetActive(false);

            yield return new WaitForSecondsRealtime(swapInterval);

            objectA.SetActive(false);
            objectB.SetActive(true);

            yield return new WaitForSecondsRealtime(swapInterval);
        }
    }
}
