using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public int bounceLimit;

    private int bouncecount = 0;
    private int time = 0;
    public GameObject explosion;
    public GameObject miniExplosion;
    private Vector2 incidentVelocity;

    private int oldScore;

    void FixedUpdate()
    {
        incidentVelocity = GetComponent<Rigidbody2D>().velocity;
        time++;
        if (time==5)
        {
            GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "TankBodyA")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = GameObject.Find("TankBodyA").transform.position;
            Destroy(GameObject.Find("TankA"), .2f);
            oldScore = PlayerPrefs.GetInt("TankBScore");
            PlayerPrefs.SetInt("TankBScore", oldScore+1);
            Destroy(gameObject);

        }
        else if (other.collider.name == "TankBodyB")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = GameObject.Find("TankBodyB").transform.position;
            Destroy(GameObject.Find("TankB"), .2f);
            oldScore = PlayerPrefs.GetInt("TankAScore");
            PlayerPrefs.SetInt("TankAScore", oldScore + 1);
            Destroy(gameObject);
        }
       // else if (other.collider.tag == "PowerUp")
       // {
        //    print("help");
       //     Physics2D.IgnoreCollision(other.collider, gameObject.GetComponent<Collider2D>(), true);
      //  }
        else
            {
            bouncecount++;
            if (bouncecount > bounceLimit | other.collider.tag == "Missile")
            {
                Destroy(gameObject);
                GameObject minie = Instantiate(miniExplosion) as GameObject;
                minie.transform.position = transform.position;
            }
            else
            {
                Vector2 direction = Vector2.Reflect(incidentVelocity, other.contacts[0].normal);
                GetComponent<Rigidbody2D>().velocity = direction;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                GetComponent<Rigidbody2D>().SetRotation(angle);
            }
        }
    }
}
