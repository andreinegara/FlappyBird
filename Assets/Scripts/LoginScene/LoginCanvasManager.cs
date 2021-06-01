using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoginCanvasManager : MonoBehaviour
{
    public Text inputText;

    // Start is called before the first frame update
    void Start()
    {
        inputText = GameObject.Find("InputText").GetComponent<Text>();

        EmptyLogin();
        
    }

    // Update is called once per frame
    void EmptyLogin()
    {
        if (PlayerPrefs.HasKey("login"))
        {
            PlayerPrefs.DeleteKey("login");
        }
    }


    //Changes to the main scene when called
    public void StartClicked()
    {
        //Doesnt move on if InputField empty
        if (!string.IsNullOrEmpty(inputText.text))
        {
            string nickname = inputText.text;

            //Updates the current login to the nickname introduced
            PlayerPrefs.SetString("login", nickname);

            //Checks for a new user 
            if (!PlayerPrefs.HasKey(nickname))
            {
                //Sets its record to zero
                PlayerPrefs.SetInt(nickname, 0);
            }
            SceneManager.LoadScene("MainGame");
        }
    }
}
