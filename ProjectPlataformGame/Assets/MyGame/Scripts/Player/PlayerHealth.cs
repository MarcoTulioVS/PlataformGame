using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int life { get; private set; }

    private int lifeAnimationIndex;

    public Animator animHud;

    public bool wasHited;
    void Start()
    {
        life = 3;
    }

    
    void Update()
    {
        
    }

    public IEnumerator DecrementLife()
    {
        if (life > 0)
        {
            wasHited = true;
            life--;
            lifeAnimationIndex += 1;
            animHud.SetInteger("transition", lifeAnimationIndex);
        }
        yield return new WaitForSeconds(1f);
        wasHited = false;
        
    }

}
