using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    private Slider Slider { get; set; }
    private Text text;
    private Text textLevelNumber;

    // Use this for initialization
    void Start ()
    {
        Slider = GetComponentInChildren<Slider>();
        text = GetComponentsInChildren<Text>()[0];
        textLevelNumber = GetComponentsInChildren<Text>()[1];
        text.text = "";
        //textLevelNumber.text = "Level "+ SceneManager.GetActiveScene().name;
        textLevelNumber.text = "find your friend";
    }
	
	// Update is called once per frame
	void Update ()
    {    

        if (GameController.Instance.GameState == GameState.Gameover)
        {
            text.text = "you run out of time";

            textLevelNumber.text = "sorry...";
        }
        else if (GameController.Instance.GameState == GameState.Finished)
        {
            text.text = "you found your friend!";

            textLevelNumber.text = "thats it, thanks for playing";
        }
        else if (GameController.Instance.GameState == GameState.Started)
        {
            Slider.value = GameController.Instance.Timer;
        }
    }

}
