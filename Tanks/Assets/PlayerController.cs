using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3f;
    public float rotateSpeed = 120f;

    public Rigidbody2D rb;
    public float moveAngleThresh = 3;
    public float turnThresh = 90;

    private float angle;
    private Quaternion qAngle;
    private Quaternion qAngle180;
    private Quaternion pAngle180;
    private float change;


    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        if (Mathf.Abs(movement.x) > 0.1 || Mathf.Abs(movement.y) > 0.1)
        {
            
            angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg + -90;
            qAngle = Quaternion.AngleAxis(angle, Vector3.forward);
            qAngle180 = qAngle;
            qAngle180.y = -qAngle180.y;
            qAngle180.z = -qAngle180.z;
            if (Mathf.Abs(Quaternion.Angle(rb.transform.rotation, qAngle)) > turnThresh)
            {
                rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, qAngle180, rotateSpeed * Time.deltaTime);
            }
            else
            {
                rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, qAngle, rotateSpeed * Time.deltaTime);
            }
            

        }
        pAngle180 = rb.transform.rotation;
        pAngle180.y = -pAngle180.y;
        pAngle180.z = -pAngle180.z;
        if (Mathf.Abs(Quaternion.Angle(rb.transform.rotation, qAngle)) <= moveAngleThresh || Mathf.Abs(Quaternion.Angle(pAngle180, qAngle)) <= moveAngleThresh)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }


}

