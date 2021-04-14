using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momie : MonoBehaviour
{
    public Trap trapScript;
    private BoxCollider2D boxCollider;

    public Sprite momieStop;
    public Sprite momieCalm;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trapScript.trapState)
        {
            boxCollider.enabled = true;
            spriteRenderer.sprite = momieStop;
        }
        else
        {
            boxCollider.enabled = false;
            spriteRenderer.sprite = momieCalm;
        }
    }
}
