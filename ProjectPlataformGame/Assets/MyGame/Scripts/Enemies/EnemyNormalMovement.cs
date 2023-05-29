using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalMovement : CharacterEnemy
{
    [SerializeField]
    private float movementRangeForward;

    [SerializeField]
    private float movementRangeBack;

    private bool movingFoward;

    private Vector2 initialPos;

    private bool isAttacking;

    void Start()
    {
        movingFoward = true;
        initialPos = transform.position;
    }

   
    void Update()
    {
        
    }

    public override void Movement()
    {
        if (movingFoward)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(enemy.Speed, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(-enemy.Speed, 0);
        }


        if (Vector2.Distance(transform.position, initialPos) >= movementRangeForward)
        {
            movingFoward = false;
        }

        if (Vector2.Distance(transform.position, initialPos) <= movementRangeForward - movementRangeBack)
        {
            movingFoward = true;
        }
    }

    public override void HitPlayer()
    {
        if (isAttacking && !playerHealth.wasHited)
        {
            StartCoroutine(playerHealth.DecrementLife());
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
        }

        if (collision.gameObject.tag == "shoot")
        {
            anim.SetInteger("transition", 2);
            Destroy(gameObject,0.5f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = false;
        }

    }
}
