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

    [Header("Keys")]
    public bool downKey = false;
    public bool upKey = false;

    [Header("HUD")]
    public GameObject panelHUD;
    public GameObject panelDef;

    [Header("Player")]
    public float moveSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    Vector3 startPoint;
    public float speedPercent;

    [Header("Trap")]
    public int SpikesDamage;

    [Header("Player Life")]
    public int currentHealth;
    public int maxHealth = 50;
    public GameObject deathAnim;
    public HealthBar healthBar;

    [Header("Speed")]
    public AnimationCurve speedCurve;

    private float deathAnimTime = 2f;
    private bool doOnce;

    private void Awake()
    {
        startPoint = transform.position;
    }

    void Start()
    {
        partMovementUp = Vector3.up;
        partMovementDown = Vector3.down;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        doOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Animator
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        if (rb.velocity.y < -1)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
        

        // Input
        if (Input.GetKey(KeyCode.DownArrow))
            downKey = true;
        else
            downKey = false;

        if (Input.GetKey(KeyCode.UpArrow))
            upKey = true;
        else
            upKey = false;

        

        // Life
        healthBar.SetHealth(currentHealth);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            if (doOnce)
            {
                Instantiate(deathAnim, transform.position, Quaternion.identity);
                SoundController.Instance.MakeDeathSound();
                GetComponent<SpriteRenderer>().enabled = false;
                ScoreManager.instance.DeathScore();
                doOnce = false;
            }
            deathAnimTime -= Time.deltaTime;
            if (deathAnimTime <= 0)
            {
                Destroy(gameObject);
                panelHUD.SetActive(false);
                panelDef.SetActive(true);
            }
            
        }
    }

    private void FixedUpdate()
    {
        float meters = transform.position.x - startPoint.x;
        ScoreManager.instance.ChangeScore(meters);

        float speed = speedCurve.Evaluate(meters);
        moveSpeed = speed;

        Vector2 velocity = rb.velocity;
        velocity.x = speed;
        rb.velocity = velocity;

        if (isInThisPart && upKey)
            levelPart.transform.position += partMovementUp * (speedPercent * moveSpeed) * Time.deltaTime;

        if (isInThisPart && downKey)
            levelPart.transform.position += partMovementDown * (speedPercent * moveSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelPart"))
        {
            levelPart = collision.gameObject;
            isInThisPart = true;
        }

        if (collision.gameObject.CompareTag("DamageZone"))
        {
            currentHealth -= SpikesDamage;
        }

        if (collision.gameObject.CompareTag("DeathZone"))
        {
            currentHealth = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void FootStepSound()
    {
        SoundController.Instance.MakeFootStepSound();
    }
}
