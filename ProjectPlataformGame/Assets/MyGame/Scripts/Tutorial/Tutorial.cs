using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    public void Start()
    {
        instance = this;
    }
    public List<string> dialogContentList = new List<string>();
   
}
