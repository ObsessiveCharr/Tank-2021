using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    public ParticleSystem impactEffect;


    private void OnTriggerEnter(Collider other)
    {
        IDamageabale damageabale = other.GetComponent<IDamageabale>();
        //print("hit " + other.name + "!");

        ParticleSystem explosionEffect = Instantiate(impactEffect) as ParticleSystem;
        explosionEffect.transform.position = transform.position;

        PlayerController.bulletOnScreen = false;
        // PlayerJoystick.bulletOnScreen = false;

        if (other.gameObject.CompareTag("EndZone"))
        {
            FindObjectOfType<AudioManager>().Play("Steel");
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, 1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Steel"))
        {
            FindObjectOfType<AudioManager>().Play("Steel");
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, 1);
            //Debug.Log("Cannot destroy steel wall!");
            Destroy(this.gameObject);
            if (SteelDestroyPowerUp.steelDestroy == true)
            {
                Destroy(other.gameObject);
            }
        }

        if (damageabale != null)
        {
            explosionEffect.Play();
            damageabale.TakeDamage(1);
            Destroy(explosionEffect.gameObject, 1);
            Destroy(this.gameObject);
        }
        else if (!other.gameObject.CompareTag("EndZone") && !other.gameObject.CompareTag("Steel"))
        {
            //print("hit " + other.name + "!");
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, 1);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        //print("hit " + other.name + "!");

    }

}
