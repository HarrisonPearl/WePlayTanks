using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot3 : MonoBehaviour
{
    public float fireRate;
    public float bulletSpeed;
    public float offSet;
    public GameObject bullet;
    public string PlayerTrigger;

    private float nextShot;
    private float shoot;
    private float sprayAngle = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shoot = Input.GetAxis(PlayerTrigger);
    }

    void FixedUpdate()
    {


        if (shoot > 0.9 && Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            GetComponent<ParticleSystem>().Play();
            var bulletClone0 = Instantiate(bullet, transform.position + transform.up * offSet, transform.rotation);
            var bulletClone1 = Instantiate(bullet, transform.position + transform.up * offSet, transform.rotation*Quaternion.Euler(0, 0, -sprayAngle));
            var bulletClone2 = Instantiate(bullet, transform.position + transform.up * offSet, transform.rotation*Quaternion.Euler(0, 0, sprayAngle));
            bulletClone0.GetComponent<Rigidbody2D>().AddForce(bulletClone0.transform.up * bulletSpeed * 10);
            bulletClone1.GetComponent<Rigidbody2D>().AddForce(bulletClone1.transform.up * bulletSpeed * 10);
            bulletClone2.GetComponent<Rigidbody2D>().AddForce(bulletClone2.transform.up * bulletSpeed * 10);

        }

    }
}
