using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Missile")){
            transform.localScale -= new Vector3(0.04f, 0.04f, 0);
            health -= 1;
            if (health < 1)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);

            }
        }
    }
}
