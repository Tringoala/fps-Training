using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerControlComponent : MonoBehaviour
{
    private Vector3 playerVelocity;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;

    private InputManager iManager;

    private Transform camTransform;

    private CapsuleCollider col;

    private bool isGrounded = true;

    private Rigidbody rb;

    private void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();
        iManager = InputManager.Instance;
        camTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Vector2 movement = iManager.getPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = camTransform.forward * move.z + camTransform.right*move.x;
        move.y = 0f;
        rb.velocity += move * Time.fixedDeltaTime * playerSpeed;
        

        // Changes the height position of the player..
        if (iManager.playerJumped() && isGrounded)
        {
            Debug.Log("in");
            rb.AddForce(0f, jumpHeight, 0f);
        }
    }

    public void groundState(bool stateOFplayer)
    {
        isGrounded = stateOFplayer;
    }

}
