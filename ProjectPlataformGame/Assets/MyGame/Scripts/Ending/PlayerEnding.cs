using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnding : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    public bool isMoving;

    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        anim.SetInteger("transition", 1);
        rb.velocity = new Vector2(speed,rb.velocity.y);
        
    }

    private void Stop()
    {
        anim.SetInteger("transition", 0);
        speed = 0;
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ending")
        {
            isMoving = false;
            
        }
    }
}
