using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSaveState : MonoBehaviour
{
    [SerializeField]
    private int indexLevel;

    public int IndexLevel { get { return this.indexLevel; } set { this.indexLevel = value; } }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("scene", indexLevel);
    }
}
