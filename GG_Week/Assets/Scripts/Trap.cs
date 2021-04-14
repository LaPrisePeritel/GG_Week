using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    public bool trapState = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTrapState()
    {
        if (trapState)
        {
            trapState = false;
        }
        else if (!trapState)
        {
            trapState = true;
        }
    }
}
