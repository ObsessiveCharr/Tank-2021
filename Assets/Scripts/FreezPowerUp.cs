using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezPowerUp : MonoBehaviour
{
    private Animation rotateAnim;
    public Animator anim;
    private void Start()
    {
        anim.Play("FreezPowerUpIdle");
        //rotateAnim.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("EnemyAI");
            foreach (GameObject target in gameObjects)
            {
                FindObjectOfType<AudioManager>().Play("PowerUp");

                StartCoroutine(PauseMovement(target));
                
                transform.Translate(new Vector3(0, 200, 0) * 10 * Time.deltaTime, Space.World);
                Destroy(gameObject, 15.2f);
            }
        }
    }
    IEnumerator PauseMovement(GameObject target)
    {
        //WaypointController enemies;
        target.GetComponent<WaypointController>().movementSpeed = 0f;
        target.GetComponent<EnemyWeapon>().timeToFire = Mathf.Infinity;
        //target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(15);
       target.GetComponent<WaypointController>().movementSpeed = 1.7f;        
        target.GetComponent<EnemyWeapon>().timeToFire = 0.0f;
        //target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
