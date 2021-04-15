using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool actionKey = false;

    public float movingTime = 0f;

    private Vector3 pos1, pos2;

    void Start()
    {
        pos1 = transform.position;
        pos2 = new Vector3(pos1.x + 4, 0, 0);
    }


    void Update()
    {
        if (actionKey && Input.GetKeyDown(KeyCode.Space))
            actionKey = false;
        else if (!actionKey && Input.GetKeyDown(KeyCode.Space))
            actionKey = true;
    }

    void FixedUpdate()
    {
        if (actionKey)
        {
            movingTime += Time.fixedDeltaTime;
            
        }
        else
        {
            movingTime -= Time.fixedDeltaTime;
        }

        movingTime = Mathf.Clamp(movingTime, 0f, 1f);

        transform.position = Vector3.Lerp(pos1, pos2, movingTime);
    }

}
