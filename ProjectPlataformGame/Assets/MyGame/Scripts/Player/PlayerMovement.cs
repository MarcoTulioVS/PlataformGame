using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IPlayerMovement
{
    private PlayerAnimation playerAnimation;

    public bool IsGrounded { get; set; }
    public bool isFront { get; set; }
    public bool isDucking { get; set; }
    public bool narrowArea { get ; set ; }

    private PlayerHealth playerHealth;

    public float timeStopped;

    

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
            timeStopped = 0;
            
        }
        else if(direction.x < 0 && IsGrounded)
        {
            playerAnimation.SetAnimation(1);
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFront = false;
            timeStopped = 0;
        }
        else if(direction.x==0 && IsGrounded)
        {
            playerAnimation.SetAnimation(0);

            if (timeStopped >= 10)
            {
                AudioController.instance.PlaySong(AudioController.instance.songs[1]);
                timeStopped = 0;
            }
        }
    }

    public void Jump(Rigidbody2D rb, float jumpForce)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        playerAnimation.SetAnimation(2);
        AudioController.instance.PlaySong(AudioController.instance.songs[0]); //Jump sound   
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
            if (!GameController.instance.checkpointActive)
            {
                
                StartCoroutine(GameController.instance.GameOver());
                AudioController.instance.PlaySong(AudioController.instance.songs[2]);
            }
            else
            {
                playerHealth.life = 3;
                playerHealth.lifeAnimationIndex = 0;
                AudioController.instance.PlaySong(AudioController.instance.songs[2]);
                GameController.instance.CheckPoint(this.transform);
            }
            
        }

        if (collision.gameObject.tag == "checkpoint")
        {
            GameController.instance.checkpointActive = true;
            GameController.instance.checkpoint = collision.gameObject.transform;
        }

        if (collision.gameObject.tag == "narrowArea")
        {
            narrowArea = true;
        }

        if (collision.gameObject.tag == "boss")
        {
            ActiveBoss.instance.activeBoss = true;
            ActiveBoss.instance.blockWall.SetActive(true);
            collision.gameObject.SetActive(false);
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "narrowArea")
        {
            narrowArea = false;
        }
    }
    public void MoveVertical()
    {
        playerAnimation.SetAnimation(4);

        if (!isDucking)
        {
            isDucking = true;
            AudioController.instance.PlaySong(AudioController.instance.songs[5]);
        }
    }

    private void Update()
    {
        timeStopped += Time.deltaTime;
        
    }
}
