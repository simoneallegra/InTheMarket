using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

		[SerializeField] GameObject objHUD;
		[SerializeField] GameObject player;
		[SerializeField] GameObject costTooMuch;	
		[SerializeField] GameObject alreadyGet;
		private bool isTalk;
		private float moveSpeedPlayer;


		void Start() {
			isTalk=false;
	
			moveSpeedPlayer = player.GetComponent<PlayerControl>().moveSpeed;
		}

		
		void Update(){
			//aprire shop con E


			if(Input.GetKeyDown(KeyCode.E) && isTalk){
				player.GetComponent<PlayerControl>().isfireble=false;
				Time.timeScale = 0f;
				player.GetComponent<PlayerControl>().moveSpeed = 0;
				alreadyGet.GetComponent<costTooMuch>().disactivceText();
				costTooMuch.GetComponent<costTooMuch>().disactivceText();
				objHUD.transform.GetChild(4).gameObject.SetActive(true);
				objHUD.transform.GetChild(5).gameObject.SetActive(false);
				
			}
		}

		
		void OnTriggerEnter(Collider other){
			if(other.gameObject.tag == "Player"){
				objHUD.transform.GetChild(5).gameObject.SetActive(true);
				isTalk = true;
			}
		}

		void OnTriggerExit(Collider other) {
			objHUD.transform.GetChild(5).gameObject.SetActive(false);
			isTalk = false;
		}
// per uscire con la X dallo shop
		public void quitShop(){
			player.GetComponent<PlayerControl>().isfireble=true;
			Time.timeScale = 1f;
			player.GetComponent<PlayerControl>().moveSpeed = moveSpeedPlayer;
			objHUD.transform.GetChild(4).gameObject.SetActive(false);
			
			
		}


}
