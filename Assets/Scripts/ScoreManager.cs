using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text text;
    private int score=0;

    void Start()
    {
        score = 0;
        text = GameObject.Find("Score").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //When PLayer collides with scoreArea
        if (other.gameObject.name == "scoreArea")
        {
            score += 1;

            //Changes Score text with the updated score
            text.text = "Score: " + score;
        }
    }
}
