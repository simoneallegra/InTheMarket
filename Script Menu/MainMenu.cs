using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public static class Choice{
	public static int value;
}

public class MainMenu : MonoBehaviour {
	
//--------------------------------------NAVIGAZIONE TRA MENU'-------------------------------
	
// dall'index nella build della scena attiva mi sposto alla successiva
	public void PlayGame(){
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void GoToOptions(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void GoToQuit(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
	}

	public void GoToRanking(){
		Choice.value=1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
	}

	public void GoToTutorial(){
		Choice.value=2;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
	}

	public void GoToCredits(){
		Choice.value=3;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
	}


	public void SureToQuit(){
		Application.Quit();
	}
	public void GoBackQuitToMenu(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
	}

}
