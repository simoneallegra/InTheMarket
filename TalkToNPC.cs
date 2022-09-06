using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkToNPC : MonoBehaviour {

	private bool isTalk;
	private bool i;
	[SerializeField] GameObject objHUD;
	[SerializeField] GameObject player;

	void Start () {
		i=false;
		isTalk=false;
		Data.win = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && isTalk && !Data.win){
			i=true;
			objHUD.transform.GetChild(5).gameObject.SetActive(false);
			objHUD.transform.GetChild(8).gameObject.SetActive(true);
		}

		if(Input.GetKeyDown(KeyCode.E) && isTalk && Data.win){
			player.GetComponent<PlayerControl>().calculate();
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			objHUD.transform.GetChild(5).gameObject.SetActive(true);
			isTalk = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player"){
			objHUD.transform.GetChild(5).gameObject.SetActive(false);
			isTalk = false;
			if(i) objHUD.transform.GetChild(8).gameObject.SetActive(false);
			
		}

		
	}
}
