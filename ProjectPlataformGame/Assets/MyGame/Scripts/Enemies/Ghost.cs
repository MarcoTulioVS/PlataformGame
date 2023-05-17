using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : CharacterEnemy
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
