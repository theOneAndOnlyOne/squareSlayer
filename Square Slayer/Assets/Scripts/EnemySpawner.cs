using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject particle;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)

        {

            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-7f, 7f);
            whereToSpawn = new Vector2 (randX, transform.position.y);
            Instantiate(particle, whereToSpawn, Quaternion.identity);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);

            if (spawnRate > 0.1)

            {

                spawnRate -= 0.05f;

            }

        }

    }
}
