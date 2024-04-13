using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get { return _instance; }
    }

    private FpsDenem inputActions;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        inputActions = new FpsDenem();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public Vector2 getPlayerMovement()
    {
        return inputActions.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 getMouseDelta()
    {
        Debug.Log(inputActions.Player.Look.ReadValue<Vector2>());
        return inputActions.Player.Look.ReadValue<Vector2>();
    }
    public bool playerJumped()
    {
        return inputActions.Player.Jump.triggered;
    }
}
