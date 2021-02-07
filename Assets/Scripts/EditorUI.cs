using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorUI : MonoBehaviour
{
    Button currentObjSelectionButton;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
        ObjectManager._instance.state = ObjectManager.State.ObjectPlacement;
    }
}
