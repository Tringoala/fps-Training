using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    bool isMove;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
    }

    public void OnPressedClassicMovement(InputValue ýnputValue)
    {
        Debug.Log("what");
    }

}
