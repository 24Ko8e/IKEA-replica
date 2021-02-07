using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class onBtnClick : MonoBehaviour
{
    Color color;
    MeshRenderer editableObject;

    [HideInInspector]
    public EditableObject selectedObject;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SetTexture(Color c)
    {
        color = c;
    }
    public void SetEditableObject(MeshRenderer obj)
    {
        editableObject = obj;
    }

    public void ApplyTexture()
    {
        editableObject.material.color = color;
    }

    public void SetCurrentButton()
    {
        selectedObject.SetCurrentButton(GetComponent<Button>());
    }
}
