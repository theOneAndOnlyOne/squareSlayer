using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    public int health;

    public GameObject deathEffect;

    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;

    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        sr.material = matWhite;

    }

    private void Update()

    {

        if (health <= 0)
        {


            Instantiate(deathEffect, transform.position, Quaternion.identity);
            ScoreScripts.ScoreValue += 1;
            FindObjectOfType<AudioManager>().Play("EnemyKill");
            Destroy(gameObject);

        }

        else
        {

            Invoke("ResetMaterial", 1f);

        }

    }

    void ResetMaterial()
    {

        sr.material = matDefault;

    }
}
