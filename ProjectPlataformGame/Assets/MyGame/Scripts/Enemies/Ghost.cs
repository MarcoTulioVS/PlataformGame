using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : CharacterEnemy
{
    void Start()
    {
        
    }

    
    void Update()
    {
        HitPlayer();
        Movement();
    }

    public override void HitPlayer()
    {

        //RaycastHit2D hit = Physics2D.Raycast(point.transform.position, direction, enemy.MaxVision);
       enemy.Hit = Physics2D.Raycast(point.transform.position, direction, enemy.MaxVision);

        if (enemy.Hit.collider != null)
        {
            Debug.Log(enemy.Hit.collider);
            anim.SetInteger("transition", 0);

            if (enemy.Hit.collider.gameObject.tag == "Player" && !playerHealth.wasHited && !player.isDucked)
            {
                StartCoroutine(playerHealth.DecrementLife());

                
                isFront = true;
                float distance = Vector2.Distance(transform.position, enemy.Hit.collider.transform.position);

                if (distance <= enemy.StopDistance)
                {
                    anim.SetInteger("transition", 1);
                    isFront = false;
                    rb.velocity = Vector2.zero;
                }


            }
            

        }
        else
        {
            isFront = false;
            rb.velocity = Vector2.zero;
        }



        //RaycastHit2D behindHit = Physics2D.Raycast(behindPoint.transform.position, -direction, enemy.MaxVision);
        enemy.BehindHit = Physics2D.Raycast(behindPoint.transform.position, -direction, enemy.MaxVision);

        if (enemy.BehindHit.collider != null)
        {
            if (enemy.BehindHit.transform.CompareTag("Player"))
            {
               
                isRight = !isRight;
                isFront = true;
            }
        }
        
        

    }

   

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "shoot")
        {
            Destroy(collision.gameObject);
        }
    }

}
