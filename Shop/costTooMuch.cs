using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class costTooMuch : MonoBehaviour {

	private void Start() {
		gameObject.SetActive(false);
	}
	public void activceText(){
		gameObject.SetActive(true);
	}

	public void disactivceText(){
		gameObject.SetActive(false);
	}
}
