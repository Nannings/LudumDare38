using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Camera myCamera;
    private float maxSizeCamera = 8;
    private float minSizeCamera = 4;
    private float targetCameraSize = 0;

	// Use this for initialization
	void Start ()
    {
        myCamera = GetComponent<Camera>();
        MakeCameraSizeBigger();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3( target.position.x, target.position.y, -10f);

        myCamera.orthographicSize = Mathf.Lerp(myCamera.orthographicSize, targetCameraSize, Time.deltaTime / 1.5f);
	}

    public void MakeCameraSizeBigger()
    {
        targetCameraSize = maxSizeCamera;
    }

    public void MakeCameraSizeSmaller()
    {
        targetCameraSize = minSizeCamera;
    }
}
