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
	public bool isFalling = false;
	
	private int count = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate() {
		if(isFalling) {
			if (count++ < 30) {
				transform.position += new Vector3(0.0f,0.0f,0.03f);
			} else {
				transform.position -= new Vector3(0.0f,0.0f,0.03f);
			}
				transform.Rotate (new Vector3(0.0f,4.0f,0.0f));
		}
	}
	
	void Update() {
		if (transform.position.z < -5) {
			Destroy ( gameObject );
		}
	}
	
	void OnCollisionEnter( Collision c ) {
		if (isFalling && count > 10) {
			Destroy ( gameObject );
			Score.score += 35;
		}
		
		if (GameObject.FindGameObjectsWithTag("Block").Length <= 1) {
				Application.LoadLevel ("LevelOne");
				
		}
		AudioSource.PlayClipAtPoint(blockDying, 
		gameObject.transform.position );
		//rigidbody.velocity *= -1;
	}
}
