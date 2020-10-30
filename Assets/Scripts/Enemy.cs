using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField]
    private float speed;

    public Vector2 movementDirection = Vector2.right;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(movementDirection);
    }

    public void Move(Vector2 direction)
    {
        movementDirection = direction;
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Environment"))
        {
            movementDirection *= -1f;
        }
        
    }
}
