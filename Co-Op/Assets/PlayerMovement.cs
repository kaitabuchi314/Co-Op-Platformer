using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 5f;
    bool grounded = true;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + ((move * Time.fixedDeltaTime) * speed));

        grounded = transform.GetComponentInChildren<GroundCheck>().grounded;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity += new Vector3(0, jumpForce, 0);
        }
    }
}
