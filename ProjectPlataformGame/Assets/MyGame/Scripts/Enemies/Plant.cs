using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : CharacterEnemy
{
    
    void Start()
    {
        enemy.IsReady = false;
        
    }

    
    void Update()
    {
        HitPlayer();
    }

    public override void HitPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(point.transform.position, enemy.Radius);
        
        if(hit != null)
        {
            if (hit.gameObject.tag == "Player")
            {
                
                StartCoroutine("ExecuteAttack");
            }
        }
        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(point.transform.position, enemy.Radius);
    }

    IEnumerator ExecuteAttack()
    {
        if (!enemy.IsReady)
        {
            enemy.IsReady = true;
            anim.SetInteger("transition", 1);
            StartCoroutine(playerHealth.DecrementLife());
            yield return new WaitForSeconds(1);
            anim.SetInteger("transition", 0);
            yield return new WaitForSeconds(2);
            enemy.IsReady = false;
        }
       
        
    }

}
