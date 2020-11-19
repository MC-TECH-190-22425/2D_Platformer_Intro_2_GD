using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField] 
    private LayerMask enemyLayerMask;

    [SerializeField]
    private Vector2 respawnPoint;

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

        yPositionPitfallDeath();

        colliderPitfallDeath();
    }

    void colliderPitfallDeath()
    {

    }

    void yPositionPitfallDeath()
    {
        //position.y implementation of pitfall death
        if (gameObject.transform.position.y < -25)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("SampleScene");
        //this.transform.position = respawnPoint;
        gameManager.removeLife();
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
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject currentGameObject = collider.GetComponent<GameObject>();
        // Check to see if the player is touching the enemy
        if(collider.CompareTag("Enemy"))
        {
            Debug.Log("The player is touching " + collider.tag );

            // Reduce Players HitPoints

            // Check if the player is dead

            // Reduce a life

            // Respawn Player or Restart the level
        }

        //if (collider.CompareTag("Coin"))
        //{
        //    Debug.Log("The player is touching " + collider.tag);

        //    // Increase Coin counter
        //    gameManager.addCoin();

        //    // Destroy Coin
        //    currentGameObject.SetActive(false);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
