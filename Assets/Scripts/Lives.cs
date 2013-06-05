using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	
	public static int lives = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GUIText livesText = gameObject.GetComponent<GUIText>(); 
		livesText.text =  lives.ToString();
	}
}
