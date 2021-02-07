using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARdebugger : MonoBehaviour
{
    static string debugText;
    void Start()
    {
        if (!Debug.isDebugBuild)
        {
            this.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Debug.isDebugBuild)
        {
            GetComponent<Text>().text = debugText;
        }
    }

    public static void printAR(string message)
    {
        debugText = message;
    }
}
