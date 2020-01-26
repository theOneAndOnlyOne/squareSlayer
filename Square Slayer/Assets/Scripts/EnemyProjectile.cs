using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed;
    public int damage;

    private Transform player;
    private Vector2 target;

    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        FindObjectOfType<AudioManager>().Play("EnemyBullet");

        target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {

            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            DestroyProjectile();

        }

    }

    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))
        {

            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            DestroyProjectile();
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
            other.GetComponent<Player>().TakeDamage(damage);

        }


        else if (other.CompareTag("Ground"))
        {

            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            DestroyProjectile();

        }

        else if (other.CompareTag("Projectile"))
        {

            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            DestroyProjectile();

        }

    }

    void DestroyProjectile()

    {

        Destroy(gameObject);
        

    }



}
