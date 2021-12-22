using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        anim.Play("LifePowerUpIdle");
    }
}
