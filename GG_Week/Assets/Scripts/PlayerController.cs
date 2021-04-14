using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Is Player On Block")]
    public bool isInThisPart = false;

    [Header("Ground Blocks")]
    public GameObject levelPart;
    private Vector3 partMovementUp;
    private Vector3 partMovementDown;
    public float movingSpeedUp = 1;
    public float movingSpeedDown = 1;

    [Header("Moving Platform")]
    private GameObject movingPlatform;
    public float movingPlatformSpeed = 2f;

    [Header("Keys")]
    public bool downKey = false;
    public bool upKey = false;
    public bool middleKey = false;

    [Header("Player")]
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    Vector2 playerMovement;

    void Start()
    {
        playerMovement = Vector2.right;
        partMovementUp = Vector3.up;
        partMovementDown = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            downKey = true;
        else
            downKey = false;

        if (Input.GetKey(KeyCode.A))
            upKey = true;
        else
            upKey = false;

        
    }

    private void FixedUpdate()
    {
        rb.position += playerMovement * (moveSpeed * Time.fixedDeltaTime);

        if (isInThisPart && upKey)
            levelPart.transform.position += partMovementUp * movingSpeedUp * Time.deltaTime;

        if (isInThisPart && downKey)
            levelPart.transform.position += partMovementDown * movingSpeedDown * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelPart"))
        {
            levelPart = collision.gameObject;
            isInThisPart = true;
        }
    }
}
