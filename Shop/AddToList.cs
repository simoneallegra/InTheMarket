using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToList : MonoBehaviour {

	[SerializeField] GameObject player;
	[SerializeField] GameObject positionSpawn;

	[SerializeField] GameObject inventory;
	[SerializeField] GameObject parent;
	
	
	[SerializeField] GameObject costTooMuch;

	[SerializeField] GameObject alreadyGot;
	public int cost;

	private bool inElem=false;
	public void addList(){

		foreach(GameObject item in player.GetComponent<PlayerControl>().lista){
			if(item == gameObject) inElem = true;
		}


		if(!inElem){
			alreadyGot.GetComponent<costTooMuch>().disactivceText();

		if(player.GetComponent<PlayerControl>().coinStart >= cost){
			costTooMuch.GetComponent<costTooMuch>().disactivceText();
			
		
		player.GetComponent<PlayerControl>().lista.Add(gameObject);
		player.GetComponent<PlayerControl>().coinStart -= cost;
		gameObject.transform.GetChild(3).gameObject.SetActive(true);
		gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<BulletControl>().player = player;
		gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<BulletControl>().gunObj = player.transform.GetChild(1).gameObject;
		// Debug.Log(gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.gameObject);
		// player.transform.GetChild(1).gameObject.GetComponent<GunControl>().bullet = gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;


		Instantiate<GameObject>(gameObject.transform.GetChild(3).gameObject, positionSpawn.transform.position, positionSpawn.transform.rotation, parent.transform);
		inventory.GetComponent<inverntoryScript>().addToInventory();
		}else{
			costTooMuch.GetComponent<costTooMuch>().activceText();
			alreadyGot.GetComponent<costTooMuch>().disactivceText();
		}
		}else alreadyGot.GetComponent<costTooMuch>().activceText();
	}
}
