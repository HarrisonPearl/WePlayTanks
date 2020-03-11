using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    private Vector2 movement;

    private float angle;
    private Quaternion qAngle;
    public Rigidbody2D tankRb;

    public string PlayerRotateX;
    public string PlayerRotateY;

    private float modSpeed;
    private float rotateSpeed = 800f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw(PlayerRotateX);
        movement.y = Input.GetAxisRaw(PlayerRotateY);
    }

    void FixedUpdate()
    {
        transform.position = tankRb.position;
        if (Mathf.Abs(movement.x) > 0.01 || Mathf.Abs(movement.y) > 0.01)
        {
            modSpeed = rotateSpeed * (Mathf.Abs(movement.x) + Mathf.Abs(movement.y)) / 2;

            angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
            qAngle = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qAngle, modSpeed * Time.deltaTime);

        }
    }
}
