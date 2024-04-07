using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField]
    InputActionReference actionReference;
    private InputAction test;
    private void OnEnable()
    {
        actionReference.action.Enable();
    }
    private void OnDisable()
    {
        actionReference.action.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        actionReference.action.started += context =>
        {
            Debug.Log("DO " + context);
        };
        actionReference.action.performed += context =>
        {
            Debug.Log("DO " + context);
        };
        actionReference.action.canceled += context =>
        {
            Debug.Log("DO " + context);
        };

    }

}
