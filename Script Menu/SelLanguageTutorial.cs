using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelLanguageTutorial : MonoBehaviour {

	[SerializeField] GameObject text;
	
	public void ChangeToIta(){
		text.transform.GetChild(1).gameObject.SetActive(true);
		text.transform.GetChild(2).gameObject.SetActive(false);
	}

	public void ChangeToEng(){
		text.transform.GetChild(1).gameObject.SetActive(false);
		text.transform.GetChild(2).gameObject.SetActive(true);

	}
}
