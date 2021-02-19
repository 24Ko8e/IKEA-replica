using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARdebugger : MonoBehaviour
{
    static string debugText;
    static float timer;
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

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            debugText = "";
        }
    }

    public static void printAR(string message)
    {
        debugText = message;
        timer = 2f;
    }

    void disableText()
    {
        debugText = "";
    }
}
