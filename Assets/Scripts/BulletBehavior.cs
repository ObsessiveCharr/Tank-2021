using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject bullet;
    public LayerMask enemyAi;
    public LayerMask ally;
    public ParticleSystem impactEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreLayerCollision(enemyAi, ally, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagePlayer damageabale = other.GetComponent<IDamagePlayer>();
        //print("hit " + other.name + "!");
        ParticleSystem explosionEffect = Instantiate(impactEffect) as ParticleSystem;
        explosionEffect.transform.position = transform.position;

        if (other.gameObject.CompareTag("EndZone"))
        {
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, 1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Steel"))
        {
            explosionEffect.Play();
            //Debug.Log("Cannot destroy steel wall!");
            Destroy(explosionEffect.gameObject, 1);
            Destroy(this.gameObject);
        }

        if (damageabale != null)
        {
            if (ShieldPowerUp.shieldOn == true)
            {
                //    damageabale.TakeDamage(1);
                explosionEffect.Play();
                Destroy(explosionEffect.gameObject, 1);
                Destroy(this.gameObject);
            }
            else
            {
                damageabale.TakeDamage(1);
                explosionEffect.Play();
                Destroy(explosionEffect.gameObject, 1);
                Destroy(this.gameObject);
            }


        }
        else if (!other.gameObject.CompareTag("EndZone") && !other.gameObject.CompareTag("Steel"))
        {
            //print("hit " + other.name + "!");
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, 1);
            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }

    }

}
