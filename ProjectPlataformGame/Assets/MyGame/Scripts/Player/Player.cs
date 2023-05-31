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

    public Ghost ghost;

    public bool isDucked { get; private set; }


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
        //Deve retirar a verificação do event system
        //quando for gerar a build para android
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            playerMovement.Move(playerInput.GetInput(), speed);

            if (playerInput.GetInputJump() && playerMovement.IsGrounded)
            {
                playerMovement.Jump(rb, jumpForce);
                playerMovement.IsGrounded = false;
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

            if (playerInput.GetVerticalInput() < 0)
            {
                playerMovement.MoveVertical();
                ghost.DefineAllBackgroundColor(Color.white);
                isDucked = true;
            }
            else
            {
                isDucked = false;
            }

        }//end event system verification
       
    }


}
