using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerInput : MonoBehaviour,IPlayerInput
{
    private int direction;

    private bool isJumping;

    private bool isAttacking;

    private bool noAttack;
    public void DirectionMovement(int value)
    {
        direction = value;
    }

    public void ExecuteJump(bool value)
    {
        isJumping = value;
    }

    public void ExecuteAttack(bool value)
    {
        isAttacking = value;
    }

    public void NoAttack(bool value)
    {
        noAttack = value;
    }
    public Vector3 GetInput()
    {
        return new Vector3(direction, 0, 0);
    }

    public bool GetInputAttack()
    {
        return isAttacking;
    }

    public bool GetInputJump()
    {
        return isJumping;
    }

}
