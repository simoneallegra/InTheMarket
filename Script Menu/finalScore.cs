using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalScore : MonoBehaviour {

	private int total;
	private float timer;

	void Start () {
		
		transform.GetChild(1).GetComponent<Text>().text = "" + Data.score;
		transform.GetChild(2).GetComponent<Text>().text = "" + (Data.coin * 3);
		transform.GetChild(3).GetComponent<Text>().text = "" + Data.time;
		total = Data.score + (Data.coin * 3) + Data.time;
		
		if(Data.win) total += 1000;

		transform.GetChild(4).GetComponent<Text>().text = "" + total;
	}
	
	public void ReturnToHome(){
		AudioBackGroundScript.Instance.gameObject.GetComponent<AudioSource>().Play ();
		if(SceneManager.GetActiveScene().buildIndex == 7) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -6);
		else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -4);
	}

}
