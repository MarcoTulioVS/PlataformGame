using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : CharacterEnemy
{
    public SpriteRenderer spriteBackground;
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

        RaycastHit2D hit = Physics2D.Raycast(point.transform.position, direction, enemy.MaxVision);

        if (hit.collider != null)
        {
            anim.SetInteger("transition", 0);

            if (hit.collider.gameObject.tag == "Player")
            {
                spriteBackground.color = Color.black;
                isFront = true;
                float distance = Vector2.Distance(transform.position, hit.collider.transform.position);

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
            spriteBackground.color = Color.white;
        }

        RaycastHit2D behindHit = Physics2D.Raycast(behindPoint.transform.position, -direction, enemy.MaxVision);

        if (behindHit.collider != null)
        {
            if (behindHit.transform.CompareTag("Player"))
            {
                spriteBackground.color = Color.black;
                isRight = !isRight;
                isFront = true;
            }
        }
        

    }

}