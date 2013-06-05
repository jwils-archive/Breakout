using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float startSpeed = 5.0f;
	public float maxSpeed = 30.0f;
	
	
	private float currentSpeed = 0.0f;
	// Use this for initialization
	void Start () {
		rigidbody.AddRelativeForce( new Vector3(1.0f, 0, -startSpeed));
	}
	
	void FixedUpdate() {
		currentSpeed = Vector3.Magnitude(rigidbody.velocity);
		
		if (currentSpeed != 0 && currentSpeed < startSpeed) {
			rigidbody.velocity /= currentSpeed / startSpeed;	
		}
		
		if (currentSpeed > maxSpeed) {
			rigidbody.velocity /= currentSpeed / startSpeed;	
		}
	}
	

	
	// Update is called once per frame
	void Update () {
		if (rigidbody.position.z < -5.5) {
			Lives.lives--;
			if (Lives.lives <= 0) {
				Debug.Log("Error");
				Score.score = 0;
				Lives.lives = 3;
				Application.LoadLevel ("LevelOne");
			}
			
			rigidbody.position = new Vector3(0.0f,0.0f,0.0f);
			rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
			rigidbody.AddRelativeForce( new Vector3(1.0f, 0, -startSpeed));
		}
	
	}
	
	void OnCollisionEnter( Collision c ) {
		rigidbody.velocity *= 1.1f;
		
		if (c.gameObject.name == "Block") {
			Score.score += 10;
		} else {
			rigidbody.velocity += new Vector3(Random.Range(0,0.1f),0.0f,Random.Range(0,0.1f));
		}
	}
}
