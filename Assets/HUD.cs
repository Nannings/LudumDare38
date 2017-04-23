using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Slider slider;

    public Slider Slider { get; set; }


    // Use this for initialization
    void Start ()
    {
        Slider = GetComponentInChildren<Slider>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

}
