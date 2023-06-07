using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float movementRangeForward;

    [SerializeField]
    private float movementRangeBack;

    private bool movingFoward;

    private Vector2 initialPos;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingFoward = true;
        initialPos = transform.position;
    }

    
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (movingFoward)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(5, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(-5, 0);
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
}
