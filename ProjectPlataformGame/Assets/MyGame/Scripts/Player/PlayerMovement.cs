using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IPlayerMovement
{
    private PlayerAnimation playerAnimation;

    public bool IsGrounded { get; set; }

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;

        if (direction.x > 0 && IsGrounded)
        {
            playerAnimation.SetAnimation(1);
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else if(direction.x < 0 && IsGrounded)
        {
            playerAnimation.SetAnimation(1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(direction.x==0 && IsGrounded)
        {
            playerAnimation.SetAnimation(0);
        }
    }

    public void Jump(Rigidbody2D rb, float jumpForce)
    {
        rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        playerAnimation.SetAnimation(2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //Colission with the ground
        {
            IsGrounded = true;
        }
    }
}
