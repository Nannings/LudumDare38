using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private float scale;

	// Use this for initialization
	void Start ()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

        scale = Random.Range(1f, 3f);
        
        transform.localScale = new Vector3(scale, scale, transform.localScale.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
