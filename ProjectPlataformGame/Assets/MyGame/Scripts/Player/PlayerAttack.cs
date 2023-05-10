using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour,IPlayerAttack
{
 
    public Rigidbody2D rbPrefab;

    private Rigidbody2D rbProjectile;
    public void Attack(float force)
    {
        rbProjectile = Instantiate(rbPrefab, transform.position, Quaternion.identity);
        rbProjectile.velocity = new Vector2(force, 0);
    }

}
