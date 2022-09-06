using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score{

	public int score;
	public string name;
}

public class SaveScore : MonoBehaviour {

	private int LeaderboardLength;
	Score currentScore;
	void Start () {

		LeaderboardLength = 8;

		currentScore = new Score();

		currentScore.score = Data.score + (Data.coin * 3) + Data.time;

		if(Data.win) currentScore.score += 1000;
		
	}
	
	
	void Update () {
		currentScore.name = transform.GetChild(6).GetComponent<InputField>().text;
	}

	public void AddScoreButton(){

		List<Score> HighScores = new List<Score> ();

		int i = 1;

		while(i<= LeaderboardLength && PlayerPrefs.HasKey("HighScore"+i+"score")){
			Score temp = new Score();
			temp.score = PlayerPrefs.GetInt ("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString ("HighScore" + i + "name");

			HighScores.Add(temp);
			i++;
		}

		if (HighScores.Count == 0) {    

             Score _temp = new Score ();
             _temp.name = currentScore.name;
             _temp.score = currentScore.score;
             HighScores.Add (_temp);

		} else{
				for(i=1; i<=HighScores.Count && i<=LeaderboardLength; i++){
					if(currentScore.score > HighScores[i-1].score){
						Score _temp = new Score ();
						_temp.name = currentScore.name;
						_temp.score = currentScore.score;
						HighScores.Insert (i-1, _temp);
						break;
					}
					if (i == HighScores.Count && i < LeaderboardLength) {
                     Score _temp = new Score ();
                     _temp.name = currentScore.name;
                     _temp.score = currentScore.score;
                     HighScores.Add (_temp);
                     break;
                 	}
				}
			}
		
		i=1;

		//Salvataggio in PlayerPrefs

		while(i<=LeaderboardLength && i<=HighScores.Count){
			PlayerPrefs.SetString ("HighScore" + i + "name", HighScores [i - 1].name);
            PlayerPrefs.SetInt ("HighScore" + i + "score", HighScores [i - 1].score);
        	i++;
		}

		transform.GetChild(7).gameObject.SetActive(true);
		transform.GetChild(4).GetComponent<Button>().enabled = false;
	}


}
