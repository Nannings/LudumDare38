using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOff : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    private Magnet myMagnet;

    // Use this for initialization
    void Start ()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myMagnet = GetComponent<Magnet>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            //Debug.Log(myRigidBody2D.velocity * -1);

            myRigidBody2D.AddForce(myRigidBody2D.velocity * -5, ForceMode2D.Impulse);

            myMagnet.AttractedTo = null;
        }
    }
}
