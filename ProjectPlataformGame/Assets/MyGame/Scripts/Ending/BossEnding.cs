using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnding : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        anim.SetInteger("transition", 1);
    }
}
