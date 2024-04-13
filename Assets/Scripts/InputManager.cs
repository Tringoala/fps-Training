using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private FpsDenem inputActions;
    private void Awake()
    {
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
        return inputActions.Player.Look.ReadValue<Vector2>();
    }
    public bool playerJumped()
    {
        return inputActions.Player.Jump.triggered;
    }
}
