using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    private int lifeAnimationIndex;

    public Animator animHud;

    public bool wasHited;
    public bool isDead;

    public int life{ get; private set;}

    private Player player;
    void Start()
    {
        life = 3;
        player = GetComponent<Player>();
    }

   
    void Update()
    {
        Die();
        animHud.SetInteger("transition", lifeAnimationIndex);
    }

    public IEnumerator DecrementLife()
    {
        if (life > 0)
        {
            wasHited = true;
            life--;
            lifeAnimationIndex += 1;
            
        }
        yield return new WaitForSeconds(1f);
        wasHited = false;
        
    }

    public void IncrementLife()
    {
        if(life>0 && life < 3)
        {
            life++;
            lifeAnimationIndex -= 1;
            
        }
    }
    private void Die()
    {
        if (life == 0 && !GameController.instance.checkpointActive)
        {
            isDead = true;
            player.enabled = false;
            StartCoroutine(GameController.instance.GameOver());

        }
        else if(life==0 && GameController.instance.checkpointActive)
        {
            GameController.instance.CheckPoint(this.transform);
            life = 3;
            lifeAnimationIndex = 0;
            isDead = false;
            player.enabled = true;
            StopCoroutine(GameController.instance.GameOver());

        }
    }

}
