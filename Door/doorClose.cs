
// script per l'uscita dalla porta nella quale si è precedentemente entrati, si attiva solo se è stato attivato doorEnter in modo che la porta non possa
//glitchare perche successivamente disattivato

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorClose : MonoBehaviour {

	[SerializeField] GameObject thedoor;
	[SerializeField] GameObject base1;
	[SerializeField] GameObject room;
	[SerializeField] GameObject nextDoor;
	[SerializeField] GameObject stanze;
	[SerializeField] GameObject porte;

	bool inGame;

	void Start() {
		inGame = false;
	}

	void Update() {
	
	//attiva la prossima stanza e disattiva l'enter dalla prima (quando tutti i nemici sono eliminati)
		 if(room.transform.GetChild(0).childCount == 0 && inGame){ 

			 //Attiva il nuovo collider per l'apertura della porta senza nemici
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			gameObject.transform.GetChild(1).gameObject.SetActive(true);
		
			for (int j=0; j<5; j++){
				stanze.transform.GetChild(j).gameObject.SetActive(true);
				if(stanze.transform.GetChild(j).gameObject.name == room.name) break;
			}

			for (int j=0; j<5; j++){
				porte.transform.GetChild(j).gameObject.SetActive(true);
				if(porte.transform.GetChild(j).gameObject.name == nextDoor.name) break;
			}


			nextDoor.transform.GetChild(3).gameObject.SetActive(true);
			nextDoor.transform.GetChild(3).gameObject.GetComponent<doorEnter>().openable=true; // attiva l'ingresso alla stanza successiva
			base1.GetComponent<doorEnter>().enabled=false;
			gameObject.GetComponent<Collider>().enabled=false;

			inGame=false;
			
		 }
	}
	void OnTriggerExit ( Collider obj ){
		
			if(base1.GetComponent<doorEnter>().isOpen && GameObject.FindGameObjectWithTag("Player").tag == obj.tag){

				StartCoroutine(chiusura());
				base1.GetComponent<doorEnter>().isOpen = false;

				//disattiva tutte le stanze eccetto la stanza giocata
				for (int j=0; j<5; j++){
					if(stanze.transform.GetChild(j).gameObject.name != room.name){
						stanze.transform.GetChild(j).gameObject.SetActive(false);
						inGame = true;
					}
				}

				//disattiva tutte le porte eccetto quelle della stanza giocata
				for (int j=0; j<5; j++){
					// Debug.Log(porte.transform.GetChild(j).gameObject.name);

					if(porte.transform.GetChild(j).gameObject.name != thedoor.name){
						
						if(porte.transform.GetChild(j).gameObject.name != nextDoor.name){
							porte.transform.GetChild(j).gameObject.SetActive(false);
						}
					}
					
					Debug.Log("ciao" + j);
				}
				

				nextDoor.transform.GetChild(3).gameObject.SetActive(false);
				base1.GetComponent<doorEnter>().openable = false;
				gameObject.transform.GetChild(0).gameObject.SetActive(true); //attivo il collider della porta cosi che non si possa tornare indietro una volta che si entra
				//anche se l'animazione della chiusura non è completata
				room.transform.GetChild(0).gameObject.SetActive(true); //attivo la stanza
				
			}
		
	}

//apertura e chiusura sono nelle coroutine cosi che possano completare la propria animazione
	IEnumerator chiusura(){
		yield return new WaitForSeconds(0.5f);
		thedoor.transform.GetChild(0).gameObject.GetComponent<Animation>().Stop("open");
		thedoor.transform.GetChild(0).gameObject.GetComponent<Animation>().Play("close");
	}

}
