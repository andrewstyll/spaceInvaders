using UnityEngine;
using System.Collections;

public class defenderController : MonoBehaviour {

	//define camera to control bounds of window
	public Camera camera;

	// Use this for initialization
	void Start () {
		if (camera == null) {
			camera = Camera.main;
		}
	}
	
	// called once per physics step
	void FixedUpdate () {
	
	}
}
