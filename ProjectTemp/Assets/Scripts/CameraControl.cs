using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraControl : NetworkBehaviour
{
    bool authority;
    public float Speed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!isLocalPlayer)
        {
            GetComponent<Camera>().enabled = false;
            GetComponent<AudioListener>().enabled = false;
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rotate();
        }
        else
            Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float y = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            y = -1;
        }

        rb.velocity = new Vector3(x, 0, z) * Speed * Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad) + new Vector3(0, y, 0) * Speed;
    }

    void Rotate()
    {
        float y = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        transform.Rotate(x, y, 0);
    }
}
