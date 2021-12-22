using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fireBullet;

    public float bulletSpeed = 30;
    public float lifeTime = 3;

    private float minWaitToFire = 1.0f;
    private float maxWaitToFire = 3.0f;
    public float timeToFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > this.timeToFire)
        {
            this.timeToFire = Time.time + Random.Range(this.minWaitToFire, this.maxWaitToFire);
            Fire();

        }
        
    }
    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, fireBullet.position, fireBullet.rotation);
        bullet.transform.position = fireBullet.position;
        bullet.GetComponent<Rigidbody>().AddForce(fireBullet.forward * bulletSpeed, ForceMode.Impulse);

       // StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

  /*  private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    } */
}
