using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool actionKey = false;

    public PlayerController player;

    private float movingTime = 0f;
    private float speed = 0.1f;
    
    [Range(0f, 1f)]
    public float playerSpeedPercent;
    

    private Vector3 pos1, pos2;

    void Start()
    {
        pos1 = transform.position;
        pos2 = new Vector3(pos1.x + 4, 0, 0);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (actionKey && Input.GetKeyDown(KeyCode.Space))
            actionKey = false;
        else if (!actionKey && Input.GetKeyDown(KeyCode.Space))
            actionKey = true;

        speed = playerSpeedPercent * player.moveSpeed;
    }

    void FixedUpdate()
    {
        if (actionKey)
        {
            movingTime +=  speed * Time.fixedDeltaTime;
        }
        else
        {
            movingTime -= speed * Time.fixedDeltaTime;
        }

        movingTime = Mathf.Clamp(movingTime, 0f, 1f);

        transform.position = Vector3.Lerp(pos1, pos2, movingTime);
    }

}
