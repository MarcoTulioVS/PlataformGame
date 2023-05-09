using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerInput playerInput;

    private IPlayerMovement playerMovement;

    [SerializeField]
    private float speed;

    private void Awake()
    {
        playerInput = GetComponent<IPlayerInput>();
        playerMovement = GetComponent<IPlayerMovement>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {

        playerMovement.Move(playerInput.GetInput(), speed);
    }
}
