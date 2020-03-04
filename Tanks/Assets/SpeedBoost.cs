using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public int tankSpeedModifier;
    private float bulletSpeedModifier = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            if (collision.transform.GetComponent<PlayerController>().moveSpeed < 2)//probably shouldnt be a const
            {
                collision.transform.GetComponent<PlayerController>().moveSpeed *= tankSpeedModifier;
                collision.transform.GetComponent<PlayerController>().rotateSpeed *= tankSpeedModifier;
                if (collision.transform.parent.transform.Find("Tower"))
                {
                    if (collision.transform.parent.transform.Find("Tower").Find("Gun"))
                        collision.transform.parent.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bulletSpeed *= bulletSpeedModifier;
                    if (collision.transform.parent.transform.Find("Tower").Find("gunUp(Clone)"))
                        collision.transform.parent.transform.Find("Tower").Find("gunUp(Clone)").GetComponent<shoot3>().bulletSpeed *= bulletSpeedModifier;

                }


                Destroy(gameObject);
            }
            
        }
    }
}
