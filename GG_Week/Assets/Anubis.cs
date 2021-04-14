using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    private Vector3 playerPos;

    public bool isAnubisOutOfScreen = true;

    public float anubisMoveSpeed = 2f;
    public float slowAnubisMoveSpeed = 1f;
    public int anubisDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        if (isAnubisOutOfScreen)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, anubisMoveSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Animation d'attaque
            playerController.TakeDamage(anubisDamage);


        }
    }
}
