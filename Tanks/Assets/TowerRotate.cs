using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    private Vector2 movement;
    public float rotateSpeed = 250f;
    private float angle;
    private Quaternion qAngle;
    public Rigidbody2D tankRb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Mouse X");
        movement.y = Input.GetAxisRaw("Mouse Y");
    }

    void FixedUpdate()
    {
        transform.position = tankRb.position;
        if (Mathf.Abs(movement.x) > 0.1 || Mathf.Abs(movement.y) > 0.1)
        {
            angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
            qAngle = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qAngle, rotateSpeed * Time.deltaTime);

        }
    }
}
