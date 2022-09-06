using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullettEnemy : MonoBehaviour {

	[SerializeField] float moveSpeed;
	[SerializeField] int damageToGive;
	private Rigidbody rb;
	Vector3 moveDirection;
	private GameObject target;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		target = GameObject.FindGameObjectWithTag("Player");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
	}

	// transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerControl>().HitPlayer(damageToGive);
			Destroy (gameObject);
		} else Destroy (gameObject);
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag != "Enemy" || other.gameObject.tag != "ColliderIgnore"){
			Destroy(gameObject);
		}
	}

	
}
