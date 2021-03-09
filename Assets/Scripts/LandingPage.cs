using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingPage : MonoBehaviour
{
    public GameObject shopNowPage;
    public GameObject catalogPage;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (shopNowPage.activeInHierarchy && !catalogPage.activeInHierarchy)
            {
                Application.Quit();
            }
            else if(!shopNowPage.activeInHierarchy && catalogPage.activeInHierarchy)
            {
                shopNowPage.SetActive(true);
                catalogPage.SetActive(false);
            }
        }
    }

    public void OpenARScene()
    {
        SceneManager.LoadScene(1);
    }
}
