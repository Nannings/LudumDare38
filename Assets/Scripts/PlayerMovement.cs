using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speedForce = 10f;
    float torqueForce = 200f;
    Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb = GetComponent<Rigidbody2D>();

        //rb.velocity = ForwardVelocity() + RightVelocity();

        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(transform.up * speedForce);
        }


        if (Input.GetButton("Brakes"))
        {
            rb.AddForce(transform.up * -speedForce / 2);
        }

        rb.angularVelocity = (Input.GetAxis("Horizontal") * torqueForce);

        // float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 10);

        //rb.angularVelocity = (Input.GetAxis("Horizontal") * tf);
    }


    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }
}
