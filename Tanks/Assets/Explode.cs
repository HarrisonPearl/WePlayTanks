using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private int bouncecount = 0;
    public GameObject explosion;
    public GameObject miniExplosion;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "TankBodyA")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = GameObject.Find("TankBodyA").transform.position;
            Destroy(GameObject.Find("TankA"), .2f);
            Destroy(gameObject);

        }
        else if (other.collider.name == "TankBodyB")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = GameObject.Find("TankBodyB").transform.position;
            Destroy(GameObject.Find("TankB"), .2f);
            Destroy(gameObject);
        }
        else
        {
            bouncecount++;
            if (bouncecount > 1) { 
            Destroy(gameObject);
            GameObject minie = Instantiate(miniExplosion) as GameObject;
            minie.transform.position = transform.position;
        }
        }
    }
}
