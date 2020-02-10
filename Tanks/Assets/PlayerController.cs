using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3f;
    public float rotateSpeed = 250f;

    public Rigidbody2D rb;
    public float moveAngleThresh = 45f;
    public float turnThresh = 90f;

    private float angle;
    private float oppAngle;
    private Quaternion qAngle;
    private Quaternion qAngle180;
    private Quaternion pAngle180;
  


    private Vector2 movement;
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

            angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
            if (angle >= 0){
              oppAngle = angle - 180;
            }
            else{
              oppAngle = angle + 180;
            }
            //Debug.Log(oppAngle);

            qAngle = Quaternion.AngleAxis(angle, Vector3.forward);
            qAngle180 = Quaternion.AngleAxis(oppAngle, Vector3.forward);

            //Debug.Log(Mathf.Abs(Quaternion.Angle(rb.transform.rotation, qAngle)));
            if (Mathf.Abs(Quaternion.Angle(rb.transform.rotation, qAngle)) <= turnThresh){
              rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, qAngle, rotateSpeed * Time.deltaTime);

              if (Mathf.Abs(Quaternion.Angle(rb.transform.rotation, qAngle)) <= moveAngleThresh){
                rb.MovePosition(rb.position + (Vector2)rb.transform.up * moveSpeed * Time.fixedDeltaTime);
              }
            }
            else{
              rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, qAngle180, rotateSpeed * Time.deltaTime);

              if (Mathf.Abs(Quaternion.Angle(rb.transform.rotation, qAngle180)) <= moveAngleThresh){
                rb.MovePosition(rb.position + -1* (Vector2)rb.transform.up * moveSpeed * Time.fixedDeltaTime);
              }
            }



        }



        // pAngle180 = rb.transform.rotation;
        // pAngle180.y = -pAngle180.y;
        // pAngle180.z = -pAngle180.z;
        // if (Mathf.Abs(Quaternion.Angle(rb.transform.rotation, qAngle)) <= moveAngleThresh || Mathf.Abs(Quaternion.Angle(pAngle180, qAngle)) <= moveAngleThresh)
        // {
        //     rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // }
    }


}
