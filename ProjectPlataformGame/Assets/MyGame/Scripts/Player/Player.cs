using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerInput playerInput;

    private IPlayerMovement playerMovement;

    private IPlayerAttack playerAttack;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float forceShoot;

    private Rigidbody2D rb;

    private bool isFired;


    private void Awake()
    {
        playerInput = GetComponent<IPlayerInput>();
        playerMovement = GetComponent<IPlayerMovement>();
        playerAttack = GetComponent<IPlayerAttack>();   
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {

        playerMovement.Move(playerInput.GetInput(), speed);

        if (playerInput.GetInputJump() && playerMovement.IsGrounded)
        {
            playerMovement.Jump(rb, jumpForce);
            playerMovement.IsGrounded = false;
        }

        if (playerInput.GetInputAttack() && !isFired)
        {
            isFired = true;
            playerAttack.Attack(forceShoot);
        }

    }

    
}
