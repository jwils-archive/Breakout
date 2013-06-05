using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public float step_speed = 20;
	public float z_offset = -5;
	public float boundry = 7.2f;
	public float wall_width = 0.2f;
	
	private Transform _t;

	// Use this for initialization
	void Start () {
		_t.position = new Vector3(0, 0, z_offset);
	}
	
	void Awake() {
		_t = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Horizontal") != 0) { 
			if (Input.GetAxisRaw ("Horizontal") < 0) {
				_t.position = new Vector3(_t.position.x - step_speed*Time.deltaTime, 0,z_offset);
			} else {
				_t.position = new Vector3(_t.position.x + step_speed*Time.deltaTime, 0,z_offset);
			}
		} 
		
		float offset = wall_width/2 + _t.localScale.x/2;
		
		if ( _t.position.x < -boundry + offset) {
			_t.position = new Vector3( -boundry + offset, 0, z_offset);
		} else if( _t.position.x > boundry - offset) {
			_t.position = new Vector3( boundry - offset, 0, z_offset);
		}
	}
}
