using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public static ActiveBoss instance;

    public bool activeBoss;

    private DragonBoss dragonBossScript;

    public GameObject blockWall;

    public GameObject lifeBarBoss;
    void Start()
    {
        instance = this;
        dragonBossScript = GetComponent<DragonBoss>();
    }

    
    void Update()
    {
        if (activeBoss)
        {
            dragonBossScript.enabled = true;
            lifeBarBoss.SetActive(true);
        }
        
    }
}
