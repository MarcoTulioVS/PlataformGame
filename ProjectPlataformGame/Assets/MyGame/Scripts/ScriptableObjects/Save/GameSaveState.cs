using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save Game/New Save Game", fileName ="New Save Game")]
public class GameSaveState : ScriptableObject
{
    [SerializeField]
    private int indexLevel;

    public int IndexLevel { get { return this.indexLevel; } set { this.indexLevel = value; } }
}
