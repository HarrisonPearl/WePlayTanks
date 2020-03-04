using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public int tankSpeedModifier;
    public int bulletSpeedModifier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            collision.transform.GetComponent<PlayerController>().moveSpeed *= tankSpeedModifier;
            collision.transform.GetComponent<PlayerController>().rotateSpeed *= tankSpeedModifier;
            if (collision.transform.Find("Tower"))
            {
                collision.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bulletSpeed *= bulletSpeedModifier;
            }
            if (collision.transform.Find("gunUp(Clone)"))
            {
                collision.transform.Find("Tower").Find("Gun").GetComponent<shoot3>().bulletSpeed *= bulletSpeedModifier;
            }

            Destroy(gameObject);
        }
    }
}
