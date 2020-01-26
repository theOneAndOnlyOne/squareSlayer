using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;

    private Transform target;
    public GameObject projectile;

    
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBtwShots = Random.Range(1f, 4f);
        
    }


    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }

        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {

            transform.position = this.transform.position;

        }

        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

        }

        if (timeBtwShots <= 0)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = Random.Range(0.5f, 2f);

        }

        else

        {

            timeBtwShots -= Time.deltaTime;

        }

    }
}
