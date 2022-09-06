using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackGroundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	private static AudioBackGroundScript instance = null;

	public static AudioBackGroundScript Instance{
		get{ return instance; }
	}

	void Awake(){
		if (instance != null && instance != this ){
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
		
	}
}
