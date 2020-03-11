using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laz : MonoBehaviour
{

    public GameObject bulletA;
    public GameObject bulletB;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            if (collision.transform.parent.transform.Find("Tower"))
            {
                if (collision.transform.parent.transform.Find("Tower").Find("Gun"))
                {
                    if(collision.name == "TankBodyA")
                        collision.transform.parent.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bullet = bulletA;
                    else
                        collision.transform.parent.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bullet = bulletB;
                }
                if (collision.transform.parent.transform.Find("Tower").Find("gunUp(Clone)"))
                {
                    if (collision.name == "TankBodyA")
                        collision.transform.parent.transform.Find("Tower").Find("gunUp(Clone)").GetComponent<shoot3>().bullet = bulletA;
                    else
                        collision.transform.parent.transform.Find("Tower").Find("gunUp(Clone)").GetComponent<shoot3>().bullet = bulletB;
                }

            }
            Destroy(gameObject);
        }
  
            
    }
}
