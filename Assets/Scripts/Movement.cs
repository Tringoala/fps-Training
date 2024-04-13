using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    InputActionReference reference;

    CinemachineVirtualCamera cm;


    Rigidbody rb;
    [SerializeField]
    float moveSpeed;
    private Vector3 _movedirection;
    public GameObject head;
    bool isMove;

    float locked;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = gameObject.GetComponent<Rigidbody>();
        locked = 5f;
    }
    private void Update()
    {
        if (locked <= 0)
        {
            gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        }
        else
        {
            locked -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        _movedirection = reference.action.ReadValue<Vector3>();
        Debug.Log(_movedirection);
        rb.AddForce(moveSpeed * Time.fixedDeltaTime * _movedirection);
//        if()
    }

    public void OnPressedClassicMovement(InputValue ýnputValue)
    {
        Debug.Log("what");
    }

}
