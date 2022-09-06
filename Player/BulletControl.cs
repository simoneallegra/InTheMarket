using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

	public float speedBullet;
	
	public int damageFire;

	[SerializeField] float timeFire;

	public GameObject player;

	public GameObject gunObj;
	void Update () {
		
		gunObj.GetComponent<GunControl>().timeOfFire = timeFire;

		transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);

		

		// Physics.IgnoreCollision(GetComponent<BoxCollider>(), player.GetComponent<BoxCollider>());

	}

	void OnCollisionEnter(Collision other) {
		// Debug.Log(other.transform.name);
		// if(other.gameObject.tag == "Enemy"){
			
		// 	other.gameObject.GetComponent<EnemyController>().HitEnemy(damageFire);
		// }
		

		if(other.gameObject.tag == "Player"){
			
			gameObject.GetComponent<BoxCollider>().isTrigger = true;
			
			
		} else{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.transform.name);

		if(other.gameObject.tag == "Enemy"){
			if(Bonus.bonusActive) damageFire += damageFire;
			other.gameObject.GetComponent<EnemyController>().HitEnemy(damageFire);
			Destroy(gameObject);
		}

		if(other.gameObject.tag != "Player") gameObject.GetComponent<BoxCollider>().isTrigger = false;

		if(other.gameObject.tag == "Scene") Destroy(gameObject);

		
		
	}

	
}
