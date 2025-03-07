using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager _instance;

    public enum State
    {
        ObjectPlacement,
        ObjectEdit
    }
    public State state;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        state = State.ObjectPlacement;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
