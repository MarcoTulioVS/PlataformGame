using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IPlayerMovement
{
    private PlayerAnimation playerAnimation;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;

        if (direction.x > 0)
        {
            playerAnimation.SetAnimation(1);
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else if(direction.x < 0)
        {
            playerAnimation.SetAnimation(1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            playerAnimation.SetAnimation(0);
        }
    }

    
}
