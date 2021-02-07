using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneUI : MonoBehaviour
{
    Button currentObjSelectionButton;
    public Color selectedColor;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetCurrentButton(Button btn)
    {
        if (currentObjSelectionButton != null)
        {
            currentObjSelectionButton.GetComponent<Image>().color = Color.white;
        }
        currentObjSelectionButton = btn;
        currentObjSelectionButton.GetComponent<Image>().color = selectedColor;
    }
}
