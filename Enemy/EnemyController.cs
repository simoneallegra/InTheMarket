using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {
	public enum EnemyType{
		ranged,
		melee
	}

	
	[SerializeField] float speed; //velocità di movimento
	[SerializeField] PlayerControl player;
	[SerializeField] int damageToGive;
	public int health; //vita
	[SerializeField] int coinToDie; //coin che droppa
	[SerializeField] int scoreToDie; //score che droppa

	public EnemyType enemyType;
	public int currentHealth;
	[SerializeField] int range; // solo ranged
	NavMeshAgent agent; //NavMesh

	void Start () {

			agent=GetComponent<NavMeshAgent>();

			player = FindObjectOfType<PlayerControl>();

			currentHealth = health;

			
	}
	
	void Update () {
	//---moviment
		
		if(enemyType == EnemyType.melee){
			agent.SetDestination(player.transform.position);
			agent.speed = speed;
			
		} else {
			if(gameObject.transform.name != "Boss"){
				gameObject.transform.LookAt(player.gameObject.transform);
			}
		}
			
	//----Life
		if (currentHealth <= 0){
			player.score += scoreToDie;
			player.coinStart += coinToDie;
			Destroy(gameObject);
		}

	}


	//riceve danno il nemico
	public void HitEnemy(int damage){

		currentHealth -= damage;
		if(gameObject.name != "Boss"){
		Vector3 currentScale = gameObject.GetComponent<Transform>().localScale;
		float scaleDamage = ((float) damage)/20f;
		gameObject.GetComponent<Transform>().localScale = currentScale/(1 + scaleDamage);
		}
	}

	//danno al player
	void OnTriggerEnter(Collider other) {
		 if(other.tag == "Player" && enemyType == EnemyType.melee){
			other.gameObject.GetComponent<PlayerControl>().HitPlayer(damageToGive);
		}
	}

	
	
}
