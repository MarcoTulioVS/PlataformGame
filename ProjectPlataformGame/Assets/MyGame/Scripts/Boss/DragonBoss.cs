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

    private bool movingFoward;

    [SerializeField]
    private float movementRangeForward;

    [SerializeField]
    private float movementRangeBack;

    private Vector2 initialPos;

    private bool inAction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initialPos = transform.position;

        StartCoroutine(ExecuteAction());
    }

    
    void Update()
    {
        timeCount += Time.deltaTime;

        if (!inAction)
        {
            Walk();
        }
        
    }

    
    IEnumerator ExecuteJump()
    {

        inAction = true;
        anim.SetInteger("transition", 2);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.1f);
        anim.SetInteger("transition", 0);
    }

    private void Attack()
    {
        
        inAction = true;
        anim.SetInteger("transition", 3);
    }

    private void Walk()
    {
        anim.SetInteger("transition", 1);

        if (movingFoward)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(10, 0);
        }
        else 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(-10, 0);
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

   

    private void Stop()
    {
        anim.SetInteger("transition", 0);
    }

    IEnumerator ExecuteAction()
    { 
        yield return new WaitForSeconds(3);
        StartCoroutine(ExecuteJump());

        yield return new WaitForSeconds(2);
        Attack();

        yield return new WaitForSeconds(1);

        inAction = false;

        yield return new WaitForSeconds(2.2f);
        Attack();

        inAction = false;
        StartCoroutine(ExecuteAction());
        
    }

    
}
