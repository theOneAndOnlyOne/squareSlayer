﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage;

    public GameObject destroyEffect;

    void Start()

    {

        FindObjectOfType<AudioManager>().Play("ShotgunShoot");

    }

    private void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {

            if (hitInfo.collider.CompareTag("Enemy"))
            {

                Debug.Log("ENEMY HAS TAKEN DMG!");
                FindObjectOfType<AudioManager>().Play("EnemyHit");
                hitInfo.collider.GetComponent<Grunt>().TakeDamage(damage);

            }

            if (hitInfo.collider.CompareTag("Explosive"))
            {

                Debug.Log("Barrel HAS TAKEN DMG!");
                FindObjectOfType<AudioManager>().Play("ExplosiveHit");
                hitInfo.collider.GetComponent<ExplosiveBarrel>().TakeDamage(damage);

            }


            DestroyProjectile();

        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
