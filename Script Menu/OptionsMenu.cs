using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;



public class OptionsMenu : MonoBehaviour {

		public void GoBackOptToMenu(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
	}
	[SerializeField] AudioMixer audioMixer;
	
	[SerializeField] Slider volumeSlider;
	[SerializeField] Dropdown resolutionDropdown;
	[SerializeField] float valueSlider;
	Resolution[] resolutions;
	void Start() {

		audioMixer.GetFloat("volume", out valueSlider);
		volumeSlider.GetComponent<Slider>().value = valueSlider;


	//pongo resolutions con la lista passatagli da schermo
		resolutions = Screen.resolutions;

	//pulisco la risoluzione	
		resolutionDropdown.ClearOptions();

	//considero la lista di opzioni
	List<string> options = new List<string>();

	//considero la risoluzione corrente
	int currentResolutionIndex=0;

	//itero il vettore resolutions
	for(int i=0; i< resolutions.Length; i++){
		// option= width x heigth
		string option = resolutions[i].width + " x " + resolutions[i].height;

		//aggiungo alle opzioni
		options.Add(option);

		//Se la resolutions iterata è quella corrente (selezionata) 
		if(resolutions[i].width == Screen.currentResolution.width &&
		resolutions[i].height == Screen.currentResolution.height){
			currentResolutionIndex=i;
		}
	}

		//Aggiungo nuova risoluzione alle opzioni
		resolutionDropdown.AddOptions(options);

		resolutionDropdown.value= currentResolutionIndex;

		resolutionDropdown.RefreshShownValue();

		//in resolution Dropdown ho quindi il valore dell'indice della risoluzione e la risoluzione, per ogni scelta
	}

	


	//setto la risoluzione con quella che ha l'indice passatogli
	public void SetResolution(int index){
		Resolution resolutionChoice = resolutions[index];
		Screen.SetResolution(resolutionChoice.width, resolutionChoice.height, Screen.fullScreen);
	}

	
	public void SetVolume( float volume){ //legge il volume dello slider
		audioMixer.SetFloat("volume", volume);
		Debug.Log(volume);

	}


	public void SetFullScreen (bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}



}
