using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerInput playerInput;

    private IPlayerMovement playerMovement;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rb;

    private bool isGrounded;
    private void Awake()
    {
        playerInput = GetComponent<IPlayerInput>();
        playerMovement = GetComponent<IPlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {

        playerMovement.Move(playerInput.GetInput(), speed);

        if (playerInput.GetInputJump() && isGrounded)
        {
            playerMovement.Jump(rb, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //Colission with the ground
        {
            isGrounded = true;
        }
    }
}
