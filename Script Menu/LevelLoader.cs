using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	[SerializeField] GameObject loadingScreen;
	[SerializeField] Slider slider;
	[SerializeField] Text progressText;

	public void LoadLevel( int sceneIndex){
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}

	//coroutine
	IEnumerator LoadAsynchronously (int sceneIndex){

			AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

			loadingScreen.SetActive(true);

		while(!op.isDone){

			float progress = Mathf.Clamp01(op.progress / 0.9F);

			slider.value=progress;

			progressText.text= progress * 100f + " %";

			//fermo la coroutine
			yield return null;
			
		}

	}
}
