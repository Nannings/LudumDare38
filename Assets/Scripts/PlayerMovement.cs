using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speedForce = 10f;
    private float torqueForce = 200f;
    private Rigidbody2D myRigidBody2D;
    private CameraFollow theCameraFollow;

    // Use this for initialization
    void Start ()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        theCameraFollow = FindObjectOfType<CameraFollow>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameController.Instance.GameState == GameState.Started)
        {
            Movement();
            CameraSize();
        }
        else
        {
            myRigidBody2D.velocity = Vector2.zero;

            if (GameController.Instance.GameState == GameState.Gameover)
            {
                GetComponent<ScaleBreath>().shrink = true;
            }
        }

    }

    public void Movement()
    {
        if (Input.GetButton("Accelerate"))
        {
            myRigidBody2D.AddForce(transform.up * speedForce);
        }


        if (Input.GetButton("Brakes"))
        {
            myRigidBody2D.AddForce(transform.up * -speedForce / 2);
        }

        myRigidBody2D.angularVelocity = (Input.GetAxis("Horizontal") * torqueForce);
    }

    public void CameraSize()
    {
        if (theCameraFollow != null)
        {
            if (myRigidBody2D.velocity.magnitude > 1)
            {
                theCameraFollow.MakeCameraSizeBigger();
            }
            else
            {
                theCameraFollow.MakeCameraSizeSmaller();
            }
        }
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(myRigidBody2D.velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(myRigidBody2D.velocity, transform.right);
    }
}
