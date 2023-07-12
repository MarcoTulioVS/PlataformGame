using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;
    public GameObject tutorialScreen;
    
    public List<string> dialogContentList = new List<string>();

    public void Start()
    {
        instance = this;
    }
}
