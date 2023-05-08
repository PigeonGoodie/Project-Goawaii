using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuteifyManager : MonoBehaviour
{
    public static int cuteifyTot;
    public static int cuteifyCount = 0;

    private void Update()
    {
        Debug.Log($"{cuteifyCount}/{cuteifyTot}");
    }

    public static void DoCuteify()
    {
        cuteifyCount++;

        if (cuteifyCount < cuteifyTot) return;

        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);

    }
}
