using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            collision.transform.GetComponent<PlayerController>().moveSpeed *= 2;
            collision.transform.GetComponent<PlayerController>().rotateSpeed *= 2;
            if (collision.transform.Find("Tower"))
            {
                collision.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bulletSpeed *= 4;
            }
            if (collision.transform.Find("gunUp(Clone)"))
            {
                collision.transform.Find("Tower").Find("Gun").GetComponent<shoot3>().bulletSpeed *= 4;
            }

            Destroy(gameObject);
        }
    }
}
