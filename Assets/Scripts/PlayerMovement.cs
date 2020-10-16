using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce;
    

    private Rigidbody2D rb;

    private float moveDirection;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        Move();
        
    }

    // Physics Movements
    void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
        
    }

    // Process Keyboard Inputs
    void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private bool IsGrounded()
    {

        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
}
