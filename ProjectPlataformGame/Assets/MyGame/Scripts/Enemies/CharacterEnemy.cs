using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterEnemy : MonoBehaviour,IEnemy
{
    public Transform point;
    public Transform behindPoint;

    public Transform pointAttack;

    public Vector2 direction;

    protected Rigidbody2D rb;

    public Enemy enemy;
    public bool isFront { get ; set ; }
    public bool isRight { get ; set ; }

    public Animator anim { get; private set; }

    public PlayerHealth playerHealth;

    public Player player;

    
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
        Gizmos.DrawWireSphere(pointAttack.position,enemy.Radius);
    }

    public virtual void HitPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.transform.position, direction, enemy.MaxVision);

        if (hit.collider != null)
        {
            //N�O APAGAR AINDA. REVISAR CASO NECESSARIO.
            //anim.SetInteger("transition", 0);

            if (hit.collider.gameObject.tag == "Player")
            {
                
                isFront = true;
                float distance = Vector2.Distance(transform.position, hit.collider.transform.position);
                

                if (distance <= enemy.StopDistance)
                {
                    
                    anim.SetInteger("transition", 1);
                    isFront = false;
                    rb.velocity = Vector2.zero;

                    Collider2D col = Physics2D.OverlapCircle(pointAttack.position, enemy.Radius);

                    if (col != null)
                    {
                        if (col.gameObject.tag == "Player" && !playerHealth.wasHited)
                        {
                            StartCoroutine(playerHealth.DecrementLife());
                        }
                    }
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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "shoot")
        {

            anim.SetInteger("transition", 2);
            Destroy(gameObject, 0.5f);
        }
    }
}
