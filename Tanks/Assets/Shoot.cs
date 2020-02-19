using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate;
    public float bulletSpeed;
    public float offSet;
    public GameObject bullet;
    public string PlayerTrigger;

    private float nextShot;
    private float shoot;

    
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


        if(shoot > 0.9 && Time.time > nextShot)
        {
                nextShot = Time.time + fireRate;
            GetComponent<ParticleSystem>().Play();
            var bulletClone = Instantiate(bullet, transform.position + transform.up * offSet, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed * 10);
            
        }

    }
}
