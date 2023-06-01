using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IPlayerMovement
{
    private PlayerAnimation playerAnimation;

    public bool IsGrounded { get; set; }
    public bool isFront { get; set; }

    private PlayerHealth playerHealth;
    private void Awake()
    {
        isFront = true;
        playerAnimation = GetComponent<PlayerAnimation>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;

        if (direction.x > 0 && IsGrounded)
        {
            playerAnimation.SetAnimation(1);
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFront = true;
            
        }
        else if(direction.x < 0 && IsGrounded)
        {
            playerAnimation.SetAnimation(1);
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFront = false;
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

        if(collision.gameObject.layer == 8) //Collision with obstacle
        {
            StartCoroutine(playerHealth.DecrementLife());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "life")
        {
            playerHealth.IncrementLife();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "final")
        {
            GameController.instance.NextScene();
        }

        if (collision.gameObject.tag == "death")
        {
            StartCoroutine(GameController.instance.GameOver());
        }
    }
    public void MoveVertical()
    {
        playerAnimation.SetAnimation(4);
    }

}
