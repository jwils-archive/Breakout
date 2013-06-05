using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Camera backCamera;
	public Camera topDownCamera;
	
	// Use this for initialization
	void Start () {
		topDownCamera.camera.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") || Input.GetKeyDown("space")) { 
			Debug.Log("hey");
			if ( backCamera.active) {
				backCamera.camera.active = false;
				topDownCamera.camera.active = true;
			} else {
				backCamera.camera.active = true;
				topDownCamera.camera.active = false;
			}
				
		}
	
	}
}
