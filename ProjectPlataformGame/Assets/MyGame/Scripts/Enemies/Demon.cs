using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : EnemyNormalMovement
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Movement();
        HitPlayer();
    }

    
}
