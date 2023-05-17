using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovement
{
    void Move(Vector3 direction,float speed);

    void Jump(Rigidbody2D rb, float jumpForce);

    public bool IsGrounded { get; set; }

    public bool isFront { get; set; }

    void MoveVertical();
}
