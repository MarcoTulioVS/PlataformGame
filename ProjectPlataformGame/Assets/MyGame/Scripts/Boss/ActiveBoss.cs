using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public static ActiveBoss instance;

    public bool activeBoss;

    private DragonBoss dragonBossScript;

    public GameObject blockWall;
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
        }
    }
}
