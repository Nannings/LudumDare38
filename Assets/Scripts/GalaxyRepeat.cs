using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyRepeat : MonoBehaviour
{
    private BoxCollider2D myBoxCollider2D;
    private float sizeX;
    private float sizeY;

    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        sizeX = myBoxCollider2D.size[0];
        sizeY = myBoxCollider2D.size[1];

        if (transform.position.x - (sizeX/2) > player.transform.position.x)
        {
            Vector3 newPos = transform.position;
            newPos.x = transform.position.x - sizeX - sizeX / 2;
            transform.position = newPos;
        }

        if(transform.position.x + (sizeX) < player.transform.position.x)
        {
            Vector3 newPos = transform.position;
            newPos.x = transform.position.x + sizeX + sizeX / 2;
            transform.position = newPos;
        }

        if (transform.position.y - (sizeY / 2) > player.transform.position.y)
        {
            Vector3 newPos = transform.position;
            newPos.y = transform.position.y - sizeY - sizeX / 2;
            transform.position = newPos;
        }

        if (transform.position.y + (sizeY) < player.transform.position.y)
        {
            Vector3 newPos = transform.position;
            newPos.y = transform.position.y + sizeY + sizeY / 2;
            transform.position = newPos;
        }
    }
}
