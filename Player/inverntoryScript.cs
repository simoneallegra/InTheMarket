using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inverntoryScript : MonoBehaviour {

	[SerializeField] GameObject usedGun;
	[SerializeField] GameObject player;

	
	[SerializeField] Sprite spriteBase;

	private int nWeaponUsed;
	
	private int empty;

	void Start(){
		empty = 0;
	}
	void Update (){
		
		foreach(GameObject item in player.GetComponent<PlayerControl>().lista) if(item != null) empty++;

		nWeaponUsed=usedGun.GetComponent<weaponSwitching>().nWeapon;

		for(int i=0; i<7; i++){
			
			if(i == nWeaponUsed -1) gameObject.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().color = Color.red;
			else gameObject.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().color = Color.black;
			
			if(empty == 0) gameObject.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().color = Color.black;
		}

	}

	public void addToInventory(){
		for(int i=0; i<7; i++) gameObject.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = spriteBase; //reset inventory quando aggiungo nuovo item

		foreach (GameObject item in player.GetComponent<PlayerControl>().lista){
			
			

			for(int i=0; i<7; i++){
				
					if(gameObject.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite == spriteBase){
						gameObject.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = item.transform.GetChild(2).GetComponent<Image>().sprite;
						break;
					}
			 
			}

		
		}

	}
}

