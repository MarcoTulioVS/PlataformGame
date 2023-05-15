using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour,IEnemy
{
    public Transform point;

    public Vector2 direction;

    private Rigidbody2D rb;

    public Enemy enemy;
    public bool isFront { get ; set ; }
    public bool isRight { get ; set ; }

    private void Awake()
    {
        direction = Vector2.right;
        isRight = true;

        rb = GetComponent<Rigidbody2D>();

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

    public void Movement()
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
        HitPlayer();
        Movement();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(point.position, direction * enemy.MaxVision);
    }

    public void HitPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.transform.position, direction, enemy.MaxVision);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                isFront = true;
                float distance = Vector2.Distance(transform.position, hit.collider.transform.position);
                
                Debug.Log(distance);

                if (distance <= enemy.StopDistance)
                {
                    isFront = false;
                    rb.velocity = Vector2.zero;
                }

            }
        }
    }
}
