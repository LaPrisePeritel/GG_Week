using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    

    public ParticleSystem[] particleSystems; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Particle()
    {
        foreach (var item in particleSystems)
        {
            item.Play();
        }
    }
}
