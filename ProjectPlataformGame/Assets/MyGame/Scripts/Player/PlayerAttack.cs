using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour,IPlayerAttack
{
 
    public Rigidbody2D rbPrefab;

    private Rigidbody2D rbProjectile;

    public Transform pointAttack;

    private float nextFire;

    private float fireRate = 0.7f;

    private CompanionAnimation companionAnimation;

    private void Awake()
    {
        companionAnimation = GetComponentInChildren<CompanionAnimation>();
    }
    public void Attack(float force)
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            rbProjectile = Instantiate(rbPrefab, pointAttack.position, rbPrefab.transform.rotation);
            StartCoroutine("PlayAnimationAttack");
        }

        
        rbProjectile.velocity = new Vector2(force, 0);
        Destroy(rbProjectile.gameObject, 3);
    }

    IEnumerator PlayAnimationAttack()
    {
        companionAnimation.ExecuteAnimation(1);
        yield return new WaitForSeconds(0.35f);
        companionAnimation.ExecuteAnimation(0);
    }

}
