
//quando il dungeon è completato la porta si attiva senza limitazioni

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class normalOpen : MonoBehaviour {

	[SerializeField] GameObject thedoor;

	private bool boolPlay= false;
	private bool animOpen= false;

	private void Update() {
		if(!thedoor.GetComponent<Animation>().isPlaying) boolPlay = false;
	}
	
	void OnTriggerEnter (Collider obj){
		if(GameObject.FindGameObjectWithTag("Player").tag == obj.tag && !boolPlay && !animOpen){
		
			thedoor.GetComponent<Animation>().Play("open");
			boolPlay = true;
			animOpen = true;
		}
	}
	void OnTriggerExit ( Collider obj  ){
	if(GameObject.FindGameObjectWithTag("Player").tag == obj.tag && !boolPlay && animOpen){
		
			thedoor.GetComponent<Animation>().Play("close");
			boolPlay = true;
			animOpen = false;
		}
	}




}
