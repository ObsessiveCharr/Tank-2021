using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public static bool shieldOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PowerUp");

            shieldOn = true;
            StartCoroutine(ShielfOff());
            transform.Translate(new Vector3(10, 200, 0) * 10 * Time.deltaTime, Space.World);
            Destroy(gameObject, 10.1f);
        }
    }
    private IEnumerator ShielfOff()
    {
        yield return new WaitForSeconds(10);
        shieldOn = false;
    }
}
