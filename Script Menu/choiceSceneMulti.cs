using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choiceSceneMulti : MonoBehaviour {

	void Start () {
		if(Choice.value==1) transform.GetChild(0).gameObject.SetActive(true);
		if(Choice.value==2) transform.GetChild(1).gameObject.SetActive(true);
		if(Choice.value==3) transform.GetChild(2).gameObject.SetActive(true);
	}
	
	public void GoToMainMenu(){
		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(false);
		transform.GetChild(2).gameObject.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
	}
	
}
