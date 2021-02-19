using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorUI : MonoBehaviour
{
    public GameObject editableObject;
    Camera mainCamera;
    bool bRotateObject = false;
    Vector2 lastPos = Vector2.zero;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(mainCamera.transform, Vector3.up);
        transform.Rotate(Vector3.up * 180);

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Spawnable")
                    {
                        bRotateObject = true;
                        lastPos = Input.GetTouch(0).position;
                    }
                }
            }
            
        }
        // Touching
        if (Input.touchCount > 0 && bRotateObject)
        {
            rotateObject();
        }
        // Touch up
        if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
        {
            if (bRotateObject)
            {
                bRotateObject = false;
            }
        }
    }

    private void rotateObject()
    {
        Vector2 dragDelta = Input.GetTouch(0).position - lastPos;
        editableObject.transform.Rotate(-dragDelta.x * 0.2f * Vector3.up, Space.World);
        lastPos = Input.GetTouch(0).position;
    }

    public void Close()
    {
        ObjectManager._instance.state = ObjectManager.State.ObjectPlacement;
        this.gameObject.SetActive(false);
    }

    public void DeleteObject()
    {
        ObjectManager._instance.state = ObjectManager.State.ObjectPlacement;
        Destroy(transform.parent.gameObject);
    }
}
