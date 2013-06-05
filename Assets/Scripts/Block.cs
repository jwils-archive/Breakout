using UnityEngine;
using System.Collections;

public enum Color {
	Red,
	Green,
	Blue
}
	
public class Block : MonoBehaviour {
	public Color color = Color.Red;
	public AudioClip blockDying;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter( Collision c ) {
		Debug.Log (c.gameObject.name);
		Destroy ( gameObject );
		Debug.Log(GameObject.FindGameObjectsWithTag("Block").Length);
			
		if (GameObject.FindGameObjectsWithTag("Block").Length <= 1) {
				Application.LoadLevel ("LevelOne");
				
		}
		AudioSource.PlayClipAtPoint(blockDying, 
		gameObject.transform.position );
		//rigidbody.velocity *= -1;
	}
}
