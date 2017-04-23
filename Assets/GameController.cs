using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Started, Gameover };

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    private HUD hud;
    private GameState GameState { get; set; }
    private PlayerMovement playerMovement;
    private float timer = 2;

    // Game Instance Singleton
    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }

    // Use this for initialization
    void Start ()
    {
        Singleton();

        hud = FindObjectOfType<HUD>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameState == GameState.Started)
        { 
            hud.Slider.value -= Time.deltaTime / timer;

            if (hud.Slider.value <= 0)
            {
                GameState = GameState.Gameover;

                playerMovement.GetComponent<ScaleBreath>().shrink = true;
                playerMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                playerMovement.enabled = false;

            }
        }
        else if (GameState == GameState.Gameover)
        {

        }


	}

    private void Singleton()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
