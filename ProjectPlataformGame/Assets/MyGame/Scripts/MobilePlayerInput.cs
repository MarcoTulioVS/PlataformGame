using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerInput : MonoBehaviour,IPlayerInput
{
    private int direction;
    public void DirectionMovement(int value)
    {
        direction = value;
    }
    public Vector3 GetInput()
    {
        return new Vector3(direction, 0, 0);
    }

    
}
