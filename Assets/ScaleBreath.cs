using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBreath : MonoBehaviour {

    [SerializeField]
    private float randomScale;
    [SerializeField]
    private float scaleRate = 0.1f;

    private float scale;
    private bool scaleToggle = false;

    // Use this for initialization
    void Start () {
        scale = transform.localScale.x;
        if (randomScale > 0) scale = Random.Range(1f, randomScale);

        transform.localScale = new Vector3(scale, scale, transform.localScale.z);

        StartCoroutine(CoScaleToggle());
    }
	
	// Update is called once per frame
	void Update () {
        if (scaleToggle)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(scale + scaleRate, scale + scaleRate, transform.localScale.z), Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(scale - scaleRate, scale - scaleRate, transform.localScale.z), Time.deltaTime);
        }
    }

    IEnumerator CoScaleToggle()
    {
        yield return new WaitForSeconds(1);
        scaleToggle = !scaleToggle;
        StartCoroutine(CoScaleToggle());
    }
}
