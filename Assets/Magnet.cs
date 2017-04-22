using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {

    private GameObject attractedTo;
    private float strengthOfAttraction = 100.0f;
    private Rigidbody2D myRidigBody2D;

    private void Start()
    {
        myRidigBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (attractedTo != null)
        {
            //some of this code is from: http://answers.unity3d.com/questions/640504/creating-local-gravity-to-attract-specific-gameobj.html

            //get the offset between the objects
            Vector3 offset = attractedTo.transform.position - transform.position;

            //we're doing 2d physics, so don't want to try and apply z forces!
            offset.z = 0;

            //get the squared distance between the objects
            float magsqr = offset.sqrMagnitude;

            //check distance is more than 0 (to avoid division by 0) and then apply a gravitational force to the object
            //note the force is applied as an acceleration, as acceleration created by gravity is independent of the mass of the object
            if (magsqr > 0.0001f)
            {
                myRidigBody2D.AddForce(strengthOfAttraction * offset.normalized / magsqr, ForceMode2D.Force);
            }
        }
    }

    private void GettingAttachedTo(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Planet"))
        {
            if (collision.transform.parent.gameObject != attractedTo)
            {
                attractedTo = collision.transform.parent.gameObject;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GettingAttachedTo(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GettingAttachedTo(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject == attractedTo)
        {
            attractedTo = null;
        }
    }
}
