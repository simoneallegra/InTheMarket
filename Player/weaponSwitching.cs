using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSwitching : MonoBehaviour {

public int nWeapon = 1;

[SerializeField] GameObject objectGun;
[SerializeField] GameObject player;

private int previousSelectedWeapons;
	void Start () {
		selectWeapon();
	}
	
	// Update is called once per frame
	void Update () {

	if (!(Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))){

		previousSelectedWeapons = nWeapon;

		if(Input.GetAxis("Mouse ScrollWheel") > 0f ){
			if(nWeapon >= transform.childCount) nWeapon = 1;
			else nWeapon++;
		}
	
		if(Input.GetAxis("Mouse ScrollWheel") < 0f){
			if(nWeapon <= 1) nWeapon = transform.childCount;
			else nWeapon--;
		}

		if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >=1){
			nWeapon = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2){
			nWeapon = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >=3){
			nWeapon = 3;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >=4){
			nWeapon = 4;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >=5){
			nWeapon = 5;
		}
		if (Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >=6){
			nWeapon = 6;
		}
		if (Input.GetKeyDown(KeyCode.Alpha7) && transform.childCount ==7){
			nWeapon = 7;
		}

		if(previousSelectedWeapons != nWeapon){
		 	selectWeapon();
		}

		if(1 == nWeapon){
		 	selectWeapon();
		}		

		
		}
	}
	
	void selectWeapon(){
		int i=0;
		
		foreach (Transform weapon in transform){
		
			foreach (GameObject item in player.GetComponent<PlayerControl>().lista){
			// Debug.Log(item.transform.GetChild(0).name+" = "+  weapon.name +" (1)(Clone)");
				if (item.transform.GetChild(0).name+" (1)(Clone)" == weapon.name ){
					
					if(i == nWeapon-1){
						
						weapon.gameObject.SetActive(true);
						// Debug.Log(weapon.name + " is "+weapon.gameObject.activeInHierarchy);
						weapon.transform.GetChild(0).gameObject.SetActive(true);
						// Debug.Log("switch:"+i);
						objectGun.GetComponent<GunControl>().i =i;

					}else{
						
						weapon.gameObject.SetActive(false);
						}
				}
			}
			i++;
		}
	}
}
