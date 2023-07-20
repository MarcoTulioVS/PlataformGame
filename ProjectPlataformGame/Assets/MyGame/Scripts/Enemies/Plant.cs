using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : CharacterEnemy
{
    public Rigidbody2D target;

    public GameObject particleObject;

    [SerializeField]
    private float radiusSuck;

    private Vector2 directionPlant;

    //public GameObject pointSuck;

    
    void Start()
    {
        enemy.IsReady = false;
        directionPlant = Vector2.left;

        
    }

    
    void Update()
    {
        HitPlayer();
        Suck();
        
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
            AudioController.instance.PlaySong(AudioController.instance.songs[4]);
            StartCoroutine(playerHealth.DecrementLife());
            yield return new WaitForSeconds(1);
            anim.SetInteger("transition", 0);
            yield return new WaitForSeconds(2);
            enemy.IsReady = false;
        }
       
        
    }

    //Trabalhar nesse metodo para fazer funcionar da maneira correta
    public void Suck()
    {
        //Collider2D hit = Physics2D.OverlapCircle(behindPoint.transform.position,radiusSuck);


        enemy.plantHit = Physics2D.Raycast(behindPoint.transform.position, directionPlant, enemy.MaxVision) ;
       
        if (enemy.plantHit.collider != null && enemy.plantHit.collider.gameObject.tag=="Player")
        {
            
            if (enemy.plantHit.collider.tag == "Player" && !isDead)
            {
                particleObject.SetActive(true);
                anim.SetInteger("transition", 3);
                target.velocity = Vector2.right * 3;
            }

        }
        else if(enemy.plantHit.collider == null && !isDead)
        {
            particleObject.SetActive(false);
            anim.SetInteger("transition", 0);
            
        }

        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(behindPoint.position, directionPlant * enemy.MaxVision);
    }




}
