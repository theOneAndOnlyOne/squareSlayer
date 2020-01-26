using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isGrounded; // detects if player is standing on the ground
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public GameObject jumpEffect;
    public GameObject deathEffect;
    public GameObject gameManager;

    public TimeManager timeManager;

    public int health;

    // Start is called before the first frame update
    void Start()
    {

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        ScoreScripts.ScoreValue = 0;

    }

    void Update()

    {

        Debug.Log(health);

        if (health <= 0)
        {

            die();

        }

        if (isGrounded == true)
        {

            extraJumps = extraJumpsValue;

        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0)

        {

            rb.velocity = Vector2.up * jumpForce;
            Instantiate(jumpEffect, transform.position, Quaternion.identity);
            extraJumps--;


        }

        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)

        {

            rb.velocity = Vector2.up * jumpForce;
            Instantiate(jumpEffect, transform.position, Quaternion.identity);

        }

        else
        {


        }

    }


    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        HealthBarScript.health -= (damage* 10f);

    }

    public void die()

    {

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        timeManager.DoSlowMotion();
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Destroy(gameObject);
        FindObjectOfType<GameManager>().EndGame();

    }

}
