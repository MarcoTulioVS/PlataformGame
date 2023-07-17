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

    
    private float speed;

    [SerializeField]
    private float auxSpeed;

    [SerializeField]
    private float radius;

    private bool isReady;

    private RaycastHit2D hit;
    private RaycastHit2D behindHit;

    public RaycastHit2D plantHit;
    public float MaxVision { get { return this.maxVision; } set { this.maxVision = value; } }

    public float StopDistance { get { return this.stopDistance; } set { this.stopDistance = value; } }
    public float Speed { get { return this.speed; } set { this.speed = value; } }
    public float Radius { get { return this.radius; } set { this.radius = value; } }
    public bool IsReady { get { return this.isReady; } set { this.isReady = value; } }

    public float AuxSpeed { get { return this.auxSpeed; } }

    public RaycastHit2D Hit { get { return this.hit; }set { this.hit = value; } }
    public RaycastHit2D BehindHit { get { return this.behindHit; }set { this.behindHit = value; } }
}
