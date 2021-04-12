using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public bool playerOnBlock = false;

    public float movingSpeed = 1;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement.z = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnBlock == true || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += movement * movingSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnBlock = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnBlock = false;
        }
    }
}
