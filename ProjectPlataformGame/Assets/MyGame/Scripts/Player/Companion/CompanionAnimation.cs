using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    

    public void ExecuteAnimation(int value)
    {
        anim.SetInteger("transition",value);
    }
}
