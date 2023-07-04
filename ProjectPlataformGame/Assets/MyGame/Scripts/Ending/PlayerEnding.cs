using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnding : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();   
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }
}
