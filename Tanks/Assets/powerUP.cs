using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUP : MonoBehaviour
{
    public string type;
    public GameObject newGun;

    private Transform gun = null;
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
        if (collision.collider.GetComponent<PlayerController>())
        {
            //Debug.Log("player hit");
            gun = collision.transform.parent.Find("Tower").Find("Gun");
            var nGun = Instantiate(newGun, gun.parent);
            nGun.transform.position = gun.position;
            nGun.transform.rotation = gun.rotation;
            Destroy(gun.gameObject);


            Destroy(gameObject);
        }
    }
}
