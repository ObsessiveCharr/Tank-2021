using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelDestroyPowerUp : MonoBehaviour
{
    public static bool steelDestroy;
    public Animator anim;

    private void Start()
    {
        anim.Play("BulletPowerUpIdle");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PowerUp");
            steelDestroy = true;
            Destroy(this.gameObject);
        }
    }

}
