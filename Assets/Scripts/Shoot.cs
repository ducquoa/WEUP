using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawner;    
    public float fireRate = 0.5f;
    private float lastFireTime;    //keep track of the time of the last shot

    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time > lastFireTime + fireRate)
        {
            InstantiateBullet();
            lastFireTime = Time.time;    // update the last shot time
        }
    }

    private void InstantiateBullet()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.SetParent(bulletSpawner);
    }
}
