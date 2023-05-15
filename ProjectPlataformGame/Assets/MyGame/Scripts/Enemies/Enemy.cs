using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/New Enemy",fileName = "New enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private float maxVision;

    [SerializeField]
    private float stopDistance;

    [SerializeField]
    private float speed;

    public float MaxVision { get { return this.maxVision; } set { this.maxVision = value; } }

    public float StopDistance { get { return this.stopDistance; } set { this.stopDistance = value; } }
    public float Speed { get { return this.speed; } set { this.speed = value; } }
}
