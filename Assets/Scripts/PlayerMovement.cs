using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float walkingSpeed = 5f;
    public float runningMultiplier = 2f;
    public float jumpForce;
    

    private Rigidbody2D rb;

    private float moveDirection;
    private bool isJumping = false;
	


	// Start is called before the first frame update
	void Start()
    {
        moveSpeed = walkingSpeed;
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

        if (Input.GetButtonDown("Fire1"))  // NOTE: When using Fire1 add z as an alternate positive button
        {
            // if the Fire1 button is pressed increase moveSpeed temporarially
            moveSpeed *= runningMultiplier;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // when the Fire1 button is released return moveSpeed to it's original value
            moveSpeed = walkingSpeed;
        }
    }

    private bool IsGrounded()
    {

        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
}
