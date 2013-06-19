using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public static int bulletCount = 0;
	public static float delay = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter( Collision c ) {		
		Destroy ( gameObject );
		bulletCount--;
		
		if (c.gameObject.name == "Block") {
			Block block = c.gameObject.GetComponent<Block>();
			block.isFalling = true;
			Score.score += 10;
		}
	}
}
