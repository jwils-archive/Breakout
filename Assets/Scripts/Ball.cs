using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float startSpeed = 10.0f;
	public float maxSpeed = 30.0f;
	
	
	private float currentSpeed = 0.0f;
	// Use this for initialization
	void Start () {
		rigidbody.AddRelativeForce( new Vector3(1.0f, 0, -startSpeed));
		gameObject.rigidbody.drag = 0; 
	}
	
	void FixedUpdate() {
		currentSpeed = Vector3.Magnitude(rigidbody.velocity);
		
		if (currentSpeed != 0 && currentSpeed < startSpeed) {
			rigidbody.velocity /= currentSpeed / startSpeed;	
		}
		
		if (currentSpeed > maxSpeed) {
			rigidbody.velocity /= currentSpeed / startSpeed;	
		}
		
		if(Mathf.Abs(rigidbody.velocity.x) > Mathf.Abs(rigidbody.velocity.z*3)) {
			if (rigidbody.velocity.z < 0) {
				rigidbody.velocity -= new Vector3(0.0f,0.0f,Mathf.Abs(rigidbody.velocity.x)*0.5f); 
			} else {
				rigidbody.velocity += new Vector3(0.0f,0.0f,Mathf.Abs(rigidbody.velocity.x)*0.5f); 
			}
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
			Block block = c.gameObject.GetComponent<Block>();
			block.isFalling = true;
		} else if(c.gameObject.name == "Paddle") {
			float deltaX = (c.contacts[0].point.x - c.gameObject.transform.position.x)/(c.gameObject.transform.localScale.x)*100;
			if (deltaX > 0) {
				rigidbody.velocity += new Vector3(deltaX*deltaX/500.0f,0.0f,0.0f);
			}else {
				rigidbody.velocity -= new Vector3(deltaX*deltaX/500.0f,0.0f,0.0f);
			}
		}
		rigidbody.velocity += new Vector3(0.0f,0.0f,Random.Range(-0.1f* currentSpeed,0.1f * currentSpeed));
	}
}
