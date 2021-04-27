using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    public bool trapState = false;

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
