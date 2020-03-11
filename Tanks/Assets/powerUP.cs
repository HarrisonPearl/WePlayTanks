using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUP : MonoBehaviour
{
    public string type;
    public GameObject newGun;
    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject lazerA;
    public GameObject lazerB;

    private Transform gun = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {

            //Debug.Log("player hit");
            gun = collision.transform.parent.Find("Tower").Find("Gun");
            var nGun = Instantiate(newGun, gun.parent);
            nGun.transform.position = gun.position;
            nGun.transform.rotation = gun.rotation;
            if (collision.transform.GetComponent<PlayerController>().moveSpeed > 2)
                nGun.GetComponent<shoot3>().bulletSpeed *= 1.5f;
            if (collision.name == "TankBodyA"){
                    if(collision.transform.parent.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bullet==lazerA)
                    nGun.GetComponent<shoot3>().bullet = lazerA;
                    else
                    nGun.GetComponent<shoot3>().bullet = bulletA;
                }
             else
                {
                    if(collision.transform.parent.transform.Find("Tower").Find("Gun").GetComponent<Shoot>().bullet==lazerB)
                    nGun.GetComponent<shoot3>().bullet = lazerB;
                    else
                    nGun.GetComponent<shoot3>().bullet = bulletB;
                }

            Destroy(gun.gameObject);


            Destroy(gameObject);
        }
    }
}
