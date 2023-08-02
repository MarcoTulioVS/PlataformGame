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

    private bool activeMove;
    
    void Start()
    {
        activeMove = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (activeMove)
        {
            if (isStopped)
            {
                Stop();
            }
            else
            {
                Move();
            }
        }
        
    }

    private void Move()
    {
        rb.velocity = new Vector3(-speed, rb.velocity.y);
    }

    private void Stop()
    {
        DialogIntro.instance.dialogBox.SetActive(true);
        DialogIntro.instance.dialogOn = true;
        rb.velocity = Vector3.zero;
        anim.SetInteger("transition", 0);
        activeMove = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "stopArea")
        {
            isStopped = true;
        }
    }

}
