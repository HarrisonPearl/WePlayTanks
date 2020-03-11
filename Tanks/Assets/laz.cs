using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laz : MonoBehaviour
{
    public GameObject lazPrefab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            if (collision.transform.parent.transform.Find("Tower"))
            {
                if (collision.transform.parent.transform.Find("Tower").Find("Gun"))
                    collision.transform.parent.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bullet = lazPrefab;
                if (collision.transform.parent.transform.Find("Tower").Find("gunUp(Clone)"))
                    collision.transform.parent.transform.Find("Tower").Find("gunUp(Clone)").GetComponent<shoot3>().bullet = lazPrefab;

            }
            Destroy(gameObject);
        }
  
            
    }
}
