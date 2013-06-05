using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public static int score = 0;
	
	void Update() {
		GUIText scoreText = gameObject.GetComponent<GUIText>(); 
		scoreText.text =  score.ToString();
	}
}
