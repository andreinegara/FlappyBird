using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private Text recordText;
    private SpawnManager spawnManager;
    private int score=0;
    private AudioSource au;
    public int record;

    //gets the login from PlayerPerf in order the display his record
    private string nickname;

    void Start()
    {
        score = 0;
        
        
       
        //stores the login in the nickname variable
        nickname = PlayerPrefs.GetString("login");

        record = PlayerPrefs.GetInt(nickname);


        //Gets the texts
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        recordText = GameObject.Find("Record").GetComponent<Text>();

        recordText.text = "Record: " + record;

        //Accesses Spawn Manager script to accelerate obstacle instanciations
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //When PLayer collides with scoreArea
        if (other.gameObject.name == "scoreArea")
        {
            score += 1;

            //Changes Score text with the updated score
            scoreText.text = "Score: " + score;

            DecreaseTime();


            UpdateRecord();

        }
    }

    //Decreases the Waiting Time in the Spawn Manager script
    //
    void DecreaseTime()
    {

        if (spawnManager.waitTime > 1.5f)
        {
            spawnManager.waitTime -= 0.1f;
        }
        else if (spawnManager.waitTime <= 1.5f && spawnManager.waitTime > 0.7f)
        {
            spawnManager.waitTime -= 0.05f;
        }
        else
        {
            spawnManager.waitTime -= 0.01f;
        }
    }

    void PlayScoreSound()
    {
        au = GetComponent<AudioSource>();
        au.Play();
    }

    void UpdateRecord()
    {
        if (score > record)
        {
            record = score;
            recordText.text = "Record: " + record;
            PlayerPrefs.SetInt(nickname, record);
        }

    }
}