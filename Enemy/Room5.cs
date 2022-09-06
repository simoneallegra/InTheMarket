using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room5 : MonoBehaviour {

	[SerializeField] GameObject spawnPoint;
	public float secondsForSpawn;
	[SerializeField] GameObject enemy;
	private float Timer;

	[SerializeField] GameObject hud;

	// Update is called once per frame
	private void Start() {
		Timer = secondsForSpawn;
		hud.transform.GetChild(7).gameObject.SetActive(true);
		hud.transform.GetChild(7).GetComponent<Slider>().maxValue = transform.GetChild(0).GetComponentInParent<EnemyController>().health;
	}
	void Update () {

		

		if(transform.childCount != 0){	
			if(transform.GetChild(0).gameObject.name != "Boss"){
				int childs = transform.childCount;
				for(int i = childs-1; i>=0; i--){
					
					Destroy(transform.GetChild(i).gameObject);
				}

				Data.win = true;
				hud.transform.GetChild(7).gameObject.SetActive(false);
			}else {
				hud.transform.GetChild(7).GetComponent<Slider>().value = transform.GetChild(0).GetComponentInParent<EnemyController>().currentHealth;
				Timer -= Time.deltaTime;
				if(Timer <= 0){
					Instantiate (enemy, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity, gameObject.transform);
					Timer = secondsForSpawn;
				}
			}
		}
	}


}
