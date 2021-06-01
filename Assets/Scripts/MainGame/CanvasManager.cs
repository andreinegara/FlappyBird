using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private GameObject player;

    private GameObject firstpanel;

    private GameObject pausePanel;

    //Flag to be updated when the game is paused
    //  also used in the PlayerJump script, to prevent jumping when paused
    public bool paused;


    //Flag that prevents the game from reopening the first screen during the game
    private bool firstScreenActive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        firstpanel = GameObject.Find("InitialPanel");
        firstpanel.SetActive(true);


        pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);


        Time.timeScale = 0;

        paused = false;

        firstScreenActive = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Tests if SpaceBar is pressed for the first time
        if (Input.GetKeyDown(KeyCode.Space) && !paused && firstScreenActive)
        {
            StartGame();

            firstScreenActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseManager();
        }

    }

    void StartGame()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerJump>().MakePlayerJump(2);
        firstpanel.SetActive(false);
    }

    public void PauseManager()
    {
        //If paused and not in the first Screen
        if (Time.timeScale == 0 && !firstScreenActive  )
        {
            Time.timeScale = 1;
            paused = false;
            pausePanel.SetActive(false);

        }

        //If not paused 
        else if(Time.timeScale == 1)
        {
            
            paused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ExitGame(){
        Application.Quit();

    }

}
