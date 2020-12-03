using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public GameManager gameManager;

    [SerializeField] 
    private LayerMask enemyLayerMask;

    public float moveSpeed = 5f;
    public float jumpForce;
    

    private Rigidbody2D rb;

    private float moveDirection;
    private bool isJumping = false;

    [SerializeField]
    private GameObject playerRespawnPoint;


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

    // Check if Grounded
    private bool IsGrounded()
    {

        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    //  Is the Player Touching something
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        // Check to see if the player is touching the enemy
        if(collider.CompareTag("Enemy"))
        {
            Debug.Log("The player is touching " + collider.tag );
            Die();
        }

        if (collider.CompareTag("DeathZone"))
        {
            Debug.Log("Player hit the death zone");
            Die();
        }
    }

    void Die()
    {
        //this.transform.position = playerRespawnPoint.transform.position;
        SceneManager.LoadScene("SampleScene");
        gameManager.removeLife();
    }

    void yPositionPitfallDeath()
    {
        if(gameObject.transform.position.y < -10)
        {
            Die();
        }
    }
}
