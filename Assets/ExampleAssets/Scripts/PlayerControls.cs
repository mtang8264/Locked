using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;

    public Vector2 rotation;
    public Vector2 rotationAcc;

    public Transform cam;
    public Transform target;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotation.x -= Input.GetAxis("Mouse Y") * rotationAcc.x;
        rotation.y += Input.GetAxis("Mouse X") * rotationAcc.y;

        cam.localEulerAngles = new Vector3(rotation.x, 0);
        transform.localEulerAngles = new Vector3(0, rotation.y);
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            target.localPosition = new Vector3();
            target.rotation = new Quaternion();
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                target.Rotate(0, -45, 0);
            }
            else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                target.Rotate(0, 45, 0);
            }
            target.Translate(0, 0, speed / 60f);

            rb.MovePosition(target.position);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            target.localPosition = new Vector3();
            target.rotation = new Quaternion();
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                target.Rotate(0, 45, 0);
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                target.Rotate(0, -45, 0);
            }
            target.Translate(0, 0, -speed / 60f);

            rb.MovePosition(target.position);
        }
        else if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            target.localPosition = new Vector3();
            target.rotation = new Quaternion();
            target.Rotate(0, -90, 0);
            target.Translate(0, 0, speed / 60f);

            rb.MovePosition(target.position);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            target.localPosition = new Vector3();
            target.rotation = new Quaternion();
            target.Rotate(0, 90, 0);
            target.Translate(0, 0, speed / 60f);

            rb.MovePosition(target.position);
        }
    }
}
