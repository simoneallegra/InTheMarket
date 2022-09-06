using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Bonus{
	public static bool bonusActive;
}


public class PlayerControl : MonoBehaviour {

	public float moveSpeed;
	private GunControl gun;
	private Camera mainCamera;
	private Ray cameraRay;
	private Plane planeForRay;
	private float lenghtRay;
	private Vector3 moveInput;                                     //Inizializzo una variabile Vector3 che indica l'imput necessario a far muovere il Player.
    private Vector3 moveVelocity;
	private CharacterController controller;


	public bool isfireble;

	//------health variables--------

	[SerializeField] int startHealth;
	private int currentHealth;
	public bool isHit;
	private float tempo;

	private float startTime;

	[SerializeField] GameObject objHUD;

	//------Coins&Shop---------------------

	public int coinStart;
	public int score;

	public List<GameObject> lista;

	void Start() {

		Bonus.bonusActive = false;

		isHit=false;
 

		startTime = 0;

		tempo =0f;

		score = 0;

		isfireble = true;

		gun= transform.GetChild(1).gameObject.GetComponent<GunControl>();

		mainCamera = FindObjectOfType<Camera>();

		controller= GetComponent<CharacterController>();

		currentHealth = startHealth;

		objHUD.transform.GetChild(1).GetComponent<Slider>().maxValue = startHealth;	

		lista = new List<GameObject>();


	} 

	void Update(){

		startTime += Time.deltaTime;

		moveInput = new Vector3(Input.GetAxis("Horizontal"),  0f, Input.GetAxis("Vertical"));
		moveVelocity = moveInput * (moveSpeed * 0.1f);

		moveVelocity.y += Physics.gravity.y*Time.deltaTime;

		controller.Move(moveVelocity);


		wMouse();

	

		//------------------------------------health---------------------------------

		objHUD.transform.GetChild(1).GetComponent<Slider>().value = currentHealth;

		if (currentHealth <= 0){
			//GAME OVER
			Debug.Log("Game Over");
			
			calculate();
			
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +3);	
		}

		//----animazione di colpo subito--------
		if(isHit){
			tempo += Time.deltaTime;
			if(tempo >=0.1) isHit=false;
		}

		//------coins---------

		objHUD.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "" +coinStart ; //aggiorno oro
		objHUD.transform.GetChild(6).transform.GetChild(1).GetComponent<Text>().text = "" +score ; // aggiorno punteggio

		// foreach(GameObject obj in lista)
		// 	{
		// 		Debug.Log(obj.name);
		// 	}
	}

	void wMouse(){
		cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
			planeForRay = new Plane(Vector3.up, Vector3.zero);
			
			if(planeForRay.Raycast(cameraRay, out lenghtRay)){
				Vector3 pointLook = cameraRay.GetPoint(lenghtRay);
				Debug.DrawLine(cameraRay.origin, pointLook, Color.blue);
				transform.LookAt(new Vector3(pointLook.x, transform.position.y, pointLook.z));
			}


			//-----------------------GUN-------------------------------
		
			if(Input.GetMouseButtonDown(0) && isfireble){				
				gun.isFire = true;
				
			}

			if(Input.GetMouseButtonUp(0)){
				
				gun.isFire = false;
				
			}
	}

	public void HitPlayer(int damage){

		currentHealth -= damage;
		Debug.Log(currentHealth);
		isHit=true;
		
	}

	public void calculate(){
			Data.score = score;
			Data.coin = coinStart;

			float t = startTime;

			Data.time = (int) (10000/t);

			Debug.Log(t);
	}

	public void Healing(){
		if(coinStart >=10){
			if(currentHealth< startHealth){
				currentHealth += startHealth/10;
				coinStart -= 10;
			} 
		} else objHUD.transform.GetChild(4).transform.GetChild(13).gameObject.SetActive(true);
	}

	public void Bonusdamage(){
		if(coinStart >= 150){
			if(!Bonus.bonusActive){
				Bonus.bonusActive = true;
				coinStart -= 150;
				objHUD.transform.GetChild(9).gameObject.SetActive(true);
			}
		} else objHUD.transform.GetChild(4).transform.GetChild(13).gameObject.SetActive(true);
	}

}	
