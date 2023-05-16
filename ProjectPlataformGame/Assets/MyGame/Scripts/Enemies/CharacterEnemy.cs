using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterEnemy : MonoBehaviour,IEnemy
{
    public Transform point;
    public Transform behindPoint;

    public Vector2 direction;

    private Rigidbody2D rb;

    public Enemy enemy;
    public bool isFront { get ; set ; }
    public bool isRight { get ; set ; }

    private Animator anim;

    private void Awake()
    {
        direction = Vector2.right;
        isRight = true;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (isRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            direction = Vector2.right;
        }
        else 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            direction = Vector2.left;
        }

    }
    public void Attack()
    {
        
    }

    public virtual void Movement()
    {
        if (isFront)
        {
            if (isRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                direction = Vector2.right;
                rb.velocity = new Vector2(enemy.Speed, rb.velocity.y);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                direction = Vector2.left;
                rb.velocity = new Vector2(-enemy.Speed, rb.velocity.y);
            }
        }
    }

   
    void Start()
    {
        
    }

    
    void Update()
    {
       
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(point.position, direction * enemy.MaxVision);
        Gizmos.DrawRay(behindPoint.position, -direction * enemy.MaxVision);
    }

    public virtual void HitPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.transform.position, direction, enemy.MaxVision);

        if (hit.collider != null)
        {
            anim.SetInteger("transition", 0);

            if (hit.collider.gameObject.tag == "Player")
            {
                
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

        RaycastHit2D behindHit = Physics2D.Raycast(behindPoint.transform.position,-direction,enemy.MaxVision);

        if(behindHit.collider != null)
        {
            if (behindHit.transform.CompareTag("Player"))
            {
               
                isRight = !isRight;
                isFront = true;
            }
        }
    }
}
