using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : CharacterEnemy
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        HitPlayer();
        Movement();
    }

   
}
