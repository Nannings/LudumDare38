using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

	// Use this for initialization
	void Start ()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

}
