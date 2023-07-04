using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionEnding : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool isMoving;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = true;
    }

    
    void Update()
    {
        if (!isMoving)
        {
            Stop();
        }
        else
        {
            Move();
        }
        
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }

    private void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dragon")
        {
            isMoving = false;

        }
    }
}
