using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : CharacterEnemy
{
    [SerializeField]
    private float movementRangeForward;

    [SerializeField]
    private float movementRangeBack;

    private bool movingFoward;

    private Vector2 initialPos;
    void Start()
    {
        movingFoward = true;
        initialPos = transform.position;    
    }

    
    void Update()
    {
        Movement();
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


}
