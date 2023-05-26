using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    private int lifeAnimationIndex;

    public Animator animHud;

    public bool wasHited;

    public int life{ get; private set;}
    void Start()
    {
        life = 3;
    }

   
    void Update()
    {
        Die();
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

    private void Die()
    {
        if (life == 0)
        {
            StartCoroutine(GameController.instance.GameOver());
        }
    }

}
