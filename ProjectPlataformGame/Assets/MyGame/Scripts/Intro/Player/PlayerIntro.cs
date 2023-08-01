using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private bool isStopped;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();

        if (isStopped)
        {
            Stop();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector3(-speed, rb.velocity.y);
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
        anim.SetInteger("transition", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "stopArea")
        {
            isStopped = true;
        }
    }

    
}
