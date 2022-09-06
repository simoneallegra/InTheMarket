
/*script per la prima entrata*/

using UnityEngine;
using System.Collections;

public class doorEnter : MonoBehaviour {
	[SerializeField] GameObject thedoor;

	[SerializeField] GameObject nextDoor;
	[SerializeField] GameObject room;
	[SerializeField] GameObject roomFrom;

	public bool openable;
	public bool isOpen;
	
	void Start()
	{
		isOpen=false;
		openable = true;
	}
	void OnTriggerEnter (Collider obj){
		
		if(!isOpen && roomFrom.activeInHierarchy && openable){
			if(GameObject.FindGameObjectWithTag("Player").tag == obj.tag){
				StartCoroutine(apertura());
				isOpen=true; //cosi che possa essere chiusa
				nextDoor.SetActive(true);
				room.SetActive(true);
				
			}		
		}
	}

	IEnumerator apertura(){

		yield return new WaitForSeconds(0.5f);

		thedoor.GetComponent<Animation>().Stop("close");
		thedoor.GetComponent<Animation>().Play("open");
		
	}



}