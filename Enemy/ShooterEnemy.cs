using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour {

	[SerializeField] GameObject bullet;
	[SerializeField] float fireRate;
	[SerializeField] GameObject gamescene;
	private float nextFire;


	void Start() {
		nextFire = Time.time;
	}
	void Update () {
		if(Time.time > nextFire){
			Instantiate(bullet, transform.position, Quaternion.identity, gamescene.transform);
			nextFire = Time.time + fireRate;
		}
		
	}
}
