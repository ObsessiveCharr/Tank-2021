using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 3.0f;
    public float bulletSpeed = 15.0f;
    public GameObject bulletPrefab;
    public Transform fireBullet;
    //bool isReadyToInstantiate;
    public ParticleSystem spawnEffect;
    public AudioSource moveSound;
    public AudioSource backgroundSound;
    public static bool bulletOnScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletOnScreen = false;
        spawnEffect.Play();
        //isReadyToInstantiate = true;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
        Vector3 moveDirection2 = new Vector3(0, 0, verticalInput);

        //moveDirection.Normalize();        

        if (moveDirection != Vector3.zero)
        {
            //playerMove.pitch = 0.5f;          
            //playerMove.Play();        
            transform.forward = moveDirection;
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);   
                     
        }       
        
        else if (moveDirection2 != Vector3.zero)
        {
            //playerMove.Play();
            transform.forward = moveDirection2;
            transform.Translate(moveDirection2 * speed * Time.deltaTime, Space.World);
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && bulletOnScreen == false)
        {
            FindObjectOfType<AudioManager>().Play("PlayerFire");
            Fire();
            bulletOnScreen = true;
        }

        if (Input.GetButton("Vertical"))
        {
            if (!moveSound.isPlaying)
            {
                moveSound.Play();
                backgroundSound.Stop();

            }
        }

        else if (Input.GetButton("Horizontal"))
        {
            if (!moveSound.isPlaying)
            {
                moveSound.Play();
                backgroundSound.Stop();
            }
        }
        else
        {
            if (!backgroundSound.isPlaying && moveSound.isPlaying)
            {
                backgroundSound.Play();
            }
            moveSound.Stop();
            
        }

    }

    private void Fire()
    {        
        GameObject bullet = Instantiate(bulletPrefab, fireBullet.position, fireBullet.rotation);
        bullet.transform.position = fireBullet.position;
        bullet.GetComponent<Rigidbody>().AddForce(fireBullet.forward * bulletSpeed, ForceMode.Impulse);
        
    }

}
