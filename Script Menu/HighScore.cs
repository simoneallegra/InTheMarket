using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HighScore : MonoBehaviour {

	private int LeaderboardLength;

	private void Start() {
		LeaderboardLength = 8;
		
		// transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = "" + PlayerPrefs.GetInt("1");
		List<Score> HighScores = GetHighScore();

		int i = 0;
		foreach(Score a in HighScores){
			Debug.Log(a.score);
			Debug.Log(a.name);

			transform.GetChild(1).transform.GetChild(i).GetComponent<Text>().text = a.name;
			transform.GetChild(2).transform.GetChild(i).GetComponent<Text>().text = ""+a.score;
			i++;

		}

	}

	public void ClearPlayerPref(){
		List<Score> HighScores = GetHighScore();
         
         for(int i=1;i<=HighScores.Count;i++)
         {
             PlayerPrefs.DeleteKey("HighScore" + i + "name");
             PlayerPrefs.DeleteKey("HighScore" + i + "score");
			 transform.GetChild(1).transform.GetChild(i-1).GetComponent<Text>().text = "-";
			transform.GetChild(2).transform.GetChild(i-1).GetComponent<Text>().text = "0";
         }
	}

	public List<Score> GetHighScore(){
		List<Score> HighScores = new List<Score> ();

		 int i = 1;
         while (i<=LeaderboardLength && PlayerPrefs.HasKey("HighScore"+i+"score")) {
             Score temp = new Score ();
             temp.score = PlayerPrefs.GetInt ("HighScore" + i + "score");
             temp.name = PlayerPrefs.GetString ("HighScore" + i + "name");
             HighScores.Add (temp);
             i++;
         }

		return HighScores;
	}
}
