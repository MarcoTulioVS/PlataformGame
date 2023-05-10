using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour,IPlayerAttack
{
 
    public Rigidbody2D rbPrefab;

    private Rigidbody2D rbProjectile;

    public Transform pointAttack;

    public void Attack(float force)
    {
        if(rbProjectile==null)
        {
            
            rbProjectile = Instantiate(rbPrefab, pointAttack.position, Quaternion.identity);
        }
        
        rbProjectile.velocity = new Vector2(force, 0);
        Destroy(rbProjectile.gameObject, 3);
    }

}
