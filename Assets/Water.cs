using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire"))
        {
            ParticleSystem fire = other.GetComponent<ParticleSystem>();
            fire.Stop();
            Console.Write("fire : ", fire.name);
        }
    }
}
