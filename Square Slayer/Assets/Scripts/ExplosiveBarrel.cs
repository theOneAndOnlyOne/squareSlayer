using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public int health;

    public GameObject deathEffect;

    public TimeManager timeManager;

    private RipplePostProcessor camRipple;

    void Start()
    {

        FindObjectOfType<AudioManager>().Play("ExplosiveSpawn");

    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();

    }

    private void Update()

    {

        if (health <= 0)
        {


            Instantiate(deathEffect, transform.position, Quaternion.identity);
            ScoreScripts.ScoreValue += 1;
            FindObjectOfType<AudioManager>().Play("Explosion");
            timeManager.DoSlowMotion();
            camRipple.RippleEffect();
            Destroy(gameObject);

        }

    }
}
