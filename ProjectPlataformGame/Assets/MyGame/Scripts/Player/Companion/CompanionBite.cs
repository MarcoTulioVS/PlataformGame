using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionBite : MonoBehaviour
{
    public float time;

    [SerializeField]
    private float maxTime;

    [SerializeField]
    private PlayerHealth playerHealth;

    public SpriteRenderer playerSprite;
    
    private CompanionAnimation anim;
    void Start()
    {
        anim = GetComponent<CompanionAnimation>();
    }

    
    void Update()
    {
        time += Time.deltaTime;
        Bite();
    }

    private void Bite()
    {
        if(playerHealth.life > 0)
        {
            if (time >= maxTime)
            {

                StartCoroutine(playerHealth.DecrementLife());
                StartCoroutine("BlinkPlayerDamage");
                time = 0;
            }
        }
        else
        {
            GameController.instance.gameTimeText.enabled = false;
        }
        
    }

    IEnumerator BlinkPlayerDamage()
    {
        playerSprite.color = Color.gray;
        anim.ExecuteAnimation(2);
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = Color.white;
        anim.ExecuteAnimation(0);
    }
}
