using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlamaCannonProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage;

    private RipplePostProcessor camRipple;

    public GameObject destroyEffect;

    void Start()

    {

        FindObjectOfType<AudioManager>().Play("PlasmaCannonShoot");
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        camRipple.RippleEffect();

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

            if (hitInfo.collider.CompareTag("Ground"))
            {

                Debug.Log("PlasmaCannon Hit Platform");
                

            }


            DestroyProjectile();

        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }


    void DestroyProjectile()
    {

        Instantiate(destroyEffect, transform.position, Quaternion.identity);

    }

}
