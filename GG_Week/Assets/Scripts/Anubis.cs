using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class Anubis : MonoBehaviour
{
    public PostProcessing postProcessing;
    private Vignette vignette;
    public GameObject player;
    public PlayerController playerController;
    private Vector3 playerPos;

    public Animator animator;

    public float anubisMoveSpeed = 2f;
    public int anubisDamage = 50;

    [Range(0f, 1f)]
    public float playerSpeedPercent;

    private Coroutine attackCoroutine;
    private float detectionTimer = 0.1f;
    private bool detectionDelay = false;

    public float timeBetweenAttack = 2f;
    // Start is called before the first frame update
    void Start()
    {
        vignette = postProcessing.volume.profile.GetSetting<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        playerPos = player.transform.position;
        playerPos.x -= 1f;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, anubisMoveSpeed * Time.deltaTime);

        if (!GetComponent<Renderer>().isVisible)
        {
            anubisMoveSpeed = playerController.moveSpeed;
            vignette.intensity.value = 0f;
        }
        else
        {
            anubisMoveSpeed = playerSpeedPercent * playerController.moveSpeed;
            vignette.intensity.value = 0.25f;
        }

        if (detectionDelay)
        {
            detectionTimer -= Time.deltaTime;
            if (detectionTimer <= 0)
            {
                detectionDelay = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!detectionDelay)
            {
                attackCoroutine = StartCoroutine(AttackCoroutine());
            } 
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detectionDelay = true;
            StopCoroutine(attackCoroutine);
            detectionTimer = 0.1f;
        }

    }

    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            WaitForSeconds wait = new WaitForSeconds(timeBetweenAttack);

            animator.SetTrigger("Attack");
            playerController.TakeDamage(anubisDamage);

            yield return wait;
        }
    }
}
