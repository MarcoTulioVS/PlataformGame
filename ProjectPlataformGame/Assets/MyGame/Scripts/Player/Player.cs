using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    public bool isDucked { get; private set; }

    private CapsuleCollider2D playerCollider;

    private float colliderSizeY;
    private float colliderOffsetY;


    private void Awake()
    {
        playerInput = GetComponent<IPlayerInput>();
        playerMovement = GetComponent<IPlayerMovement>();
        playerAttack = GetComponent<IPlayerAttack>();  
        rb = GetComponent<Rigidbody2D>();

        playerCollider = GetComponent<CapsuleCollider2D>();

    }
    void Start()
    {
        colliderSizeY = playerCollider.size.y;
        colliderOffsetY = playerCollider.offset.y;
    }


    void Update()
    {
        //Deve retirar a verificação do event system
        //quando for gerar a build para android

        playerMovement.Move(playerInput.GetInput(), speed);

        if (playerInput.GetInputJump() && playerMovement.IsGrounded)
        {
            playerMovement.IsGrounded = false;
            playerMovement.Jump(rb, jumpForce);

        }

        if (playerInput.GetInputAttack())
        {
            if (playerMovement.isFront)
            {
                playerAttack.Attack(forceShoot);
            }
            else
            {
                playerAttack.Attack(-forceShoot);
            }

        }

        if (!playerMovement.narrowArea)
        {
            if (playerInput.GetVerticalInput() < 0)
            {
                playerCollider.size = new Vector2(playerCollider.size.x, 1.26f);
                playerCollider.offset = new Vector2(playerCollider.offset.x, -0.4f);
                playerMovement.MoveVertical();
                isDucked = true;

            }
            else
            {
                playerCollider.size = new Vector2(playerCollider.size.x, colliderSizeY);
                playerCollider.offset = new Vector2(playerCollider.offset.x, colliderOffsetY);

                isDucked = false;
                playerMovement.isDucking = false;
            }
        }
        else
        {
            playerCollider.size = new Vector2(playerCollider.size.x, 1.26f);
            playerCollider.offset = new Vector2(playerCollider.offset.x, -0.4f);
            playerMovement.MoveVertical();

        }

    }


}
