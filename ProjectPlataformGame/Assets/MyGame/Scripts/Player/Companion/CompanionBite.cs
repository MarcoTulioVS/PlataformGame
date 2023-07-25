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
    void Start()
    {
        
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
                time = 0;
            }
        }
        else
        {
            GameController.instance.gameTimeText.enabled = false;
        }
        
    }
}
