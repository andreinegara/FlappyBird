using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
	private GameObject gameOverPanel;
	private AudioSourceManager soundScript;

	private void Start()
    {
		gameOverPanel = GameObject.Find("GameOverPanel");
		gameOverPanel.SetActive(false);

		soundScript = gameObject.GetComponent<AudioSourceManager>();

	}

    public void OnTriggerEnter2D (Collider2D other){
		
		if (other.gameObject.CompareTag("Obstacle")){

			soundScript.PlayCrashSound();
			gameOverPanel.SetActive(true);

			StartCoroutine(Reload());
			//Time.timeScale = 0;
			
		}
	}
	IEnumerator Reload()
    {
	
		yield return new WaitForSeconds(0.6f);
		
		SceneManager.LoadScene("MainGame");

	}
}
