using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement")]
     public float movementSpeed;
    float verticalMovement;
    float horizontalMovement;

    public float groundDrag;

    [Header("Ground Control")]

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    Vector3 movementDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //locates player's rigidbody component
        rb = GetComponent<Rigidbody>();
        //freeze's rigidbody's rotation
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //displays raycasts that looks for any ground collider below them
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        playerInput();
        speedControl();

        //handles the drag by checking if they are on the ground
        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void playerInput()
    {
        //finds the inputs from editor settings
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        playerMovement();
    }

    private void playerMovement()
    {
        //calculates the direction of movement so you move in the direction you are facing
        movementDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;

        rb.AddForce(movementDirection.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //calculates what the movement speed would be and applies it to the rigidbody
        if(flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
