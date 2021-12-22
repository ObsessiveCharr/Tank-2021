using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePowerUp : MonoBehaviour
{
    public ParticleSystem destroyEffect;
    public Animator anim;

    private void Start()
    {
        anim.Play("GrenadePowerUpIdle");
        //rotateAnim.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        

        if (other.gameObject.tag == "Player")
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("EnemyAI");
            foreach (GameObject target in gameObjects)
            {
                FindObjectOfType<AudioManager>().Play("PowerUp");
                ParticleSystem explosionEffect = Instantiate(destroyEffect) as ParticleSystem;
                explosionEffect.transform.position = target.transform.position;
                FindObjectOfType<AudioManager>().Play("Death");
                explosionEffect.Play();
                Destroy(explosionEffect.gameObject, 1.1f);
                GameObject.Destroy(target);
                Destroy(this.gameObject);
                GameManager.instance.AddScore();
                GameManager.instance.EnemyCount();
            }
        
        }
    }
 
}
