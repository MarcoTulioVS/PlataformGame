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

    public bool GetInputJump()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        return isJumping;
    }
}
