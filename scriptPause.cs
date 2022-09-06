// PAUSA A RUN TIME

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scriptPause : MonoBehaviour {

	public static bool isPause = false;

	[SerializeField] GameObject pauseMenu;
	[SerializeField] GameObject objectHidden;
	[SerializeField] AudioSource pauseAudio;

	[SerializeField] AudioSource gameAudio;
	[SerializeField] GameObject player;
	[SerializeField] GameObject hud;

	void Update () {

		//controllo di quando il gioco è messo in pausa o meno
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (isPause){
				Resume();
				gameAudio.GetComponent<AudioSource>().Play();
			}
			else{
				Pause();
				gameAudio.GetComponent<AudioSource>().Pause();
			}
		}

	}

	public void Resume (){
		 //disattiva il canvas pausa e attivo il gioco
		pauseMenu.SetActive(false);
		objectHidden.SetActive(true);
		hud.SetActive(true);
		pauseAudio.Stop(); 
		Time.timeScale= 1f; 
		isPause = false; 

	}

	void Pause (){
		 //disattiva il gioco e attivo il canvas per la pausa
		pauseMenu.SetActive(true); 
		objectHidden.SetActive(false);
		hud.SetActive(false); 
		pauseAudio.Play();
		
		Time.timeScale = 0f; //per frezzare il game
		isPause = true;	
	}

	public void toQuit(){
		//per uscire dal gioco(applicato al button nel canvas della pausa)
		Time.timeScale= 1f;
		isPause = false;
		AudioBackGroundScript.Instance.gameObject.GetComponent<AudioSource>().Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);	
	}

}
