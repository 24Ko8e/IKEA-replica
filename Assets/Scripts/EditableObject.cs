using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditableObject : MonoBehaviour
{
    public GameObject editorCanvas;
    Camera mainCamera;
    public MeshRenderer editObject;
    public GameObject btnParent;
    public GameObject btnPrefab;
    public List<Color> colors = new List<Color>();
    List<GameObject> buttons = new List<GameObject>();

    Button currentObjSelectionButton;
    public Color selectedColor;

    void Start()
    {
        mainCamera = Camera.main;
        editorCanvas.GetComponent<Canvas>().worldCamera = mainCamera;
        editorCanvas.SetActive(false);
    }

    void Update()
    {
        
    }

    public void EnableEditor()
    {
        if (!editorCanvas.activeSelf)
        {
            editorCanvas.SetActive(true);
            SetupButtons();
        }
    }

    public void DisableEditor()
    {
        editorCanvas.SetActive(false);
    }

    [ContextMenu("Create Buttons")]
    private void SetupButtons()
    {
        if (buttons.Count > 0)
        {
            return;
        }
        if (colors.Count > 0)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                GameObject btn = Instantiate(btnPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                buttons.Add(btn);
                btn.transform.SetParent(btnParent.transform);
                btn.transform.localPosition = Vector3.zero;
                btn.transform.localRotation = Quaternion.Euler(Vector3.zero);
                btn.transform.localScale = Vector3.one;
                btn.GetComponent<onBtnClick>().SetEditableObject(editObject);
                btn.GetComponent<onBtnClick>().SetTexture(colors[i]);
                btn.GetComponent<onBtnClick>().selectedObject = this;
                btn.transform.GetChild(0).GetComponent<Text>().text = "Color" + (i + 1);
            }
        }
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

    public void Delete()
    {
        ObjectManager._instance.state = ObjectManager.State.ObjectPlacement;
        Destroy(this.gameObject);
    }
}
