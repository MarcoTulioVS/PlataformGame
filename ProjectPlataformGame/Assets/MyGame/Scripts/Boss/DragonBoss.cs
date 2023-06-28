using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBoss : MonoBehaviour
{

    private Rigidbody2D rb;

    private float timeCount;

    [SerializeField]
    private float jumpForce;

    private int randomNumber;

    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        timeCount += Time.deltaTime;

        ExecuteAction();
    }

    private void Jump()
    {
        anim.SetInteger("transition", 2);
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce),ForceMode2D.Impulse);
    }

    private void Attack()
    {
        anim.SetInteger("transition", 3);
    }

    private void Walk()
    {
        anim.SetInteger("transition", 1);
    }

    private void Stop()
    {
        anim.SetInteger("transition", 0);
    }

    private void ExecuteAction()
    {
        if (randomNumber != 1 && randomNumber!=2)
        {
            Walk();
        }

        if (timeCount >= 3)
        {
            randomNumber = Random.Range(1, 5);
            Debug.Log(randomNumber);
            timeCount = 0;

            if (randomNumber == 1)
            {
                Jump();
            }
            else if(randomNumber == 2)
            {
                Attack();
            }
            
            
        }
    }
}
