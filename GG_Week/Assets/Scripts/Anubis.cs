using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    private Vector3 playerPos;

    public float anubisMoveSpeed = 2f;
    public int anubisDamage = 50;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        playerPos = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, anubisMoveSpeed * Time.deltaTime);

        if (!GetComponent<Renderer>().isVisible)
            anubisMoveSpeed = playerController.moveSpeed;
        else
            anubisMoveSpeed = 1f;
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
