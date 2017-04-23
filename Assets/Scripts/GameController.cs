using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Started, Gameover, Finished };

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    public GameState GameState { get; set; }
    public float Timer { get; set; }
    private float timeDec = 25; 

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
        Timer = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameState == GameState.Started)
        {
            if (Timer <= 0 && GameState != GameState.Gameover)
            {
                GameState = GameState.Gameover;
                StartCoroutine(CoWaitUntilPlayAgain());
            }
            else
            {
                Timer -= Time.deltaTime / timeDec;
            }
        }
        else if (GameState == GameState.Gameover)
        {

        }
        else if (GameState == GameState.Finished)
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

    IEnumerator CoWaitUntilPlayAgain()
    {
        yield return new WaitForSeconds(4);

        Timer = 1;
        GameState = GameState.Started;
        Debug.Log("reload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
