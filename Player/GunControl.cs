using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

	public bool isFire;
	public GameObject bullet;


	// [SerializeField] float newSpeedFire;
	public float timeOfFire;
	private float shotCounter;
	public Transform firePoint;
	[SerializeField] GameObject gameScene;


	public int i;

	void Start() {
		i = -1;

	}
	// void Update () {
	// 	if (isFire){
	// 		shotCounter -= Time.deltaTime;
	// 		if(shotCounter <= 0){
	// 			shotCounter = timeOfFire;
	// 			Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation, gameScene.transform);
	// 			// BulletControl newbullet = Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation, gameScene.transform) as BulletControl;
	// 			// newbullet.speedFire = newSpeedFire;
	// 		}
	// 	}else{
	// 		shotCounter = 0;
	// 	}
	// }

		void Update () {

		// foreach (GameObject item in gameObject.GetComponentInParent<PlayerControl>().lista)
		// {
		// 	if(item != null){

		// 		 bullet = item.transform.GetChild(3).transform.GetChild(0).gameObject;
		// 		 Debug.Log(bullet.name);
		// 	}

		// }

		if(i>=0) {
			Debug.Log(gameObject.transform.GetChild(2).transform.GetChild(i).transform.GetChild(0).gameObject.name);
		bullet = gameObject.transform.GetChild(2).transform.GetChild(i).transform.GetChild(0).gameObject ;

		// Debug.Log(isFire+"---"+bullet.activeInHierarchy);

			if(isFire && bullet.activeInHierarchy){
				
					shotCounter -= Time.deltaTime;
			if(shotCounter <= 0){
				shotCounter = timeOfFire;
				
				if(bullet.name == "DoritosKunaiBullot"){
					Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation * Quaternion.Euler(0, 30, 0), gameScene.transform);
					Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation * Quaternion.Euler(0, 15, 0), gameScene.transform);
					Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation * Quaternion.Euler(0, -15, 0), gameScene.transform);
					Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation * Quaternion.Euler(0, -30, 0), gameScene.transform);
				} else Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation, gameScene.transform);
				GetComponent<AudioSource>().Play();
				// BulletControl newbullet = Instantiate(bullet.GetComponent<BulletControl>(), firePoint.position, firePoint.rotation, gameScene.transform) as BulletControl;
				// newbullet.speedFire = newSpeedFire;
			}
		}else if(shotCounter >0){
				shotCounter -= Time.deltaTime;
		}else shotCounter = 0;

		}
	}
	
}
		

	

