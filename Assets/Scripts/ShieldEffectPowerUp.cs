using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffectPowerUp : MonoBehaviour
{
    public ParticleSystem shieldEffect;
    // Start is called before the first frame update
    void Start()
    {
        /*ParticleSystem shieldPower = Instantiate(shieldEffect) as ParticleSystem;
        shieldPower.transform.position = transform.position;*/
        shieldEffect.Play();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
