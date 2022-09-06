using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitAnimation : MonoBehaviour {

	[SerializeField] Material material;
	[SerializeField] GameObject obj;
	private Material startMaterial;
	void Start(){
		startMaterial=gameObject.GetComponent<Renderer>().material;
	}
	void Update () {
		if(obj.GetComponent<PlayerControl>().isHit){
			gameObject.GetComponent<Renderer>().material = material;
			GetComponent<AudioSource>().Play();
		} else gameObject.GetComponent<Renderer>().material = startMaterial;

		
	}
	

}
