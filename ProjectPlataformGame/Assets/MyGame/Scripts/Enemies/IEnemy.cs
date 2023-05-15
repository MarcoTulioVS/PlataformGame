using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Movement();
    void Attack();

    void HitPlayer();

    public bool isFront { get; set; }

    public bool isRight { get; set; }
}
