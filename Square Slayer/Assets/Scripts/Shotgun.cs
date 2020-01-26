using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (rotZ < -90 || rotZ > 90)
        {

            if (projectile.transform.eulerAngles.y == 0)
            {

                transform.localRotation = Quaternion.Euler(180f, 0f, -rotZ + offset);

            }

            else if (projectile.transform.eulerAngles.y == 100)
            {

                transform.localRotation = Quaternion.Euler(180f, 180f, -rotZ + offset);

            }

        }

        if (timeBtwShots <= 0)

        {

            if (Input.GetMouseButtonDown(0))

            {

                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;

            }

        }

        else
        {

            timeBtwShots -= Time.deltaTime;

        }


    }
}
