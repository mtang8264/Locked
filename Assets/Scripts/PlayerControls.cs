using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;

    public Vector2 rotation;
    public Vector2 rotationAcc;
    public float xRotMaxima;

    public Transform cam;
    public Transform target;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Setup();
    }

    void Update()
    {
        MouseInput();
    }

    private void FixedUpdate()
    {
        KeyboardInput();
    }

    void Setup()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void MouseInput()
    {
        rotation.x -= Input.GetAxis("Mouse Y") * rotationAcc.x;
        rotation.y += Input.GetAxis("Mouse X") * rotationAcc.y;

        if (rotation.x > xRotMaxima)
            rotation.x = xRotMaxima;
        if (rotation.x < -xRotMaxima)
            rotation.x = -xRotMaxima;

        cam.localEulerAngles = new Vector3(rotation.x, 0);
        transform.localEulerAngles = new Vector3(0, rotation.y);
    }

    void KeyboardInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            target.localPosition = new Vector3();
            target.rotation = new Quaternion();
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                target.Rotate(0, -45, 0);
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                target.Rotate(0, 45, 0);
            }
            target.Translate(0, 0, speed / 60f);

            rb.MovePosition(target.position);
        }
        else if (Input.GetKey(KeyCode.S))
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
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
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
