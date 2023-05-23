using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuteifyManager : MonoBehaviour
{
    public static int cuteifyTot;
    public static int cuteifyCount = 0;

    private static List<GameObject> cuteifyObjects;

    private void Awake()
    {
        cuteifyObjects = new List<GameObject>();
    }

    public static void AddCuteifyObject(GameObject obj)
    {
        cuteifyObjects.Add(obj);
        cuteifyTot++;
    }

    public static void DoCuteify(GameObject obj)
    {
        if (!cuteifyObjects.Contains(obj)) return;

        cuteifyObjects.Remove(obj);
        cuteifyCount++;

        if (cuteifyCount < cuteifyTot) return;

        Debug.Log("All cuteifyed");

        //GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseManager>().OpenWinScreen();
        //SceneManager.LoadScene("StartScene", LoadSceneMode.Single);

    }
}
