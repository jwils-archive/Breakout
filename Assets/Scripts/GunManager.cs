using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {
	public Camera mainCamera;
	public GameObject bullet;
	public AudioClip laser;

	private Camera _cam; 
	
	
	// Use this for initialization
	void Start () {
	_cam = (Camera) Camera.Instantiate(mainCamera);
		_cam.GetComponent<AudioListener>().enabled = false ;
		_cam.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		Bullet.delay += Time.deltaTime;
		if (_cam.enabled) {
			_cam.transform.position = gameObject.transform.position ;
			_cam.transform.LookAt(gameObject.transform.position + new Vector3(0,0,10));
			
			
			if ((Input.GetButtonDown ("Fire1") || Input.GetKeyDown("space")) && Bullet.bulletCount < 8 && Bullet.delay > 1.0f) { 
				AudioSource.PlayClipAtPoint(laser, 
		gameObject.transform.position );
				Bullet.bulletCount++;
				Bullet.delay = 0.0f;
				GameObject obj = Instantiate(bullet, new Vector3(gameObject.transform.position.x,0, gameObject.transform.position.z + 0.4f), Quaternion.identity) as GameObject;
				obj.rigidbody.AddRelativeForce(new Vector3(0,0,100));
				obj.rigidbody.drag = 0;
				//Bullet b = obj.GetComponenet<Bullet>();
				
			}
		}
		
		
		
		
		if (Input.GetKeyDown("f")) {  
			if ( mainCamera.enabled) {
				mainCamera.enabled = false;
				_cam.enabled = true;
			} else {
				mainCamera.enabled = true;
				_cam.enabled = false;
			}
				
		}
		
		
	
	}
}