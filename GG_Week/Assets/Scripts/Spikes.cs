using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Trap trapScript;

    public Animator animator;

    public GameObject child;
    private BoxCollider2D boxCollider2;

    private void Start()
    {
        boxCollider2 = child.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (trapScript.trapState)
        {
            animator.SetBool("IsOn", true);
            boxCollider2.enabled = false;
        }
        else
        {
            animator.SetBool("IsOn", false);
            boxCollider2.enabled = true;
        }
    }
}
