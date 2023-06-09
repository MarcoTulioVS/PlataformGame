using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerInput : MonoBehaviour,IPlayerInput
{
    public Vector3 GetInput()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        return new Vector3(horizontalMovement, 0, 0);
    }

    public bool GetInputAttack()
    {
        bool isAttacking = Input.GetButtonDown("Fire1");
        return isAttacking;
    }

    public bool GetInputJump()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        return isJumping;
    }

    public float GetVerticalInput()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        return verticalMovement;
    }

}
