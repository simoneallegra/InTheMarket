//VIDEO CASA DI PRODUZIONE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptIntro : MonoBehaviour {

	private float timer = 9f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <=0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		
		if (Input.GetMouseButtonDown(0)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		
	}

}
