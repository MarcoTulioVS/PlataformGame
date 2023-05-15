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

    private IPlayerMovement playerMovement;

    private void Awake()
    {
        companionAnimation = GetComponentInChildren<CompanionAnimation>();
        playerMovement = GetComponent<IPlayerMovement>();
    }
    public void Attack(float force)
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            rbProjectile = Instantiate(rbPrefab, pointAttack.position, rbPrefab.transform.rotation);

            if (playerMovement.isFront)
            {
                rbProjectile.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else
            {
                rbProjectile.transform.eulerAngles = new Vector3(0, 180, 90);
            }
            StartCoroutine("PlayAnimationAttack");
        }

        
        rbProjectile.velocity = new Vector2(force, 0);
        Destroy(rbProjectile.gameObject, 1);
    }

    IEnumerator PlayAnimationAttack()
    {
        companionAnimation.ExecuteAnimation(1);
        yield return new WaitForSeconds(0.35f);
        companionAnimation.ExecuteAnimation(0);
    }

}
