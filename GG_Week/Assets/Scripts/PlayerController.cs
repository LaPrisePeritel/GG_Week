using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        movement.x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.position += movement * (moveSpeed * Time.fixedDeltaTime);
    }

}
