using UnityEngine;
using System.Collections;

public class defenderController : MonoBehaviour {

	//define camera to control bounds of window
	public Camera cam;
	public float maxSpeed;

	private Rigidbody2D defender;
	private float maxWidth;
	private float defenderWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		if (maxSpeed == 0.0f) {
			maxSpeed = 5f;
		}

		defender = GetComponent<Rigidbody2D> ();

		defenderWidth = GetComponent<Renderer> ().bounds.extents.x;
		Vector3 maxCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 maxCornerW = cam.ScreenToWorldPoint(maxCorner);
		maxWidth = maxCornerW.x - defenderWidth/2;
	}
	
	// called once per physics timestep
	void FixedUpdate () {
	//need to find pointer first then use that to move defender

		Vector3 pointPosition = cam.ScreenToWorldPoint(Input.mousePosition);

		float targetPositionWidth = Mathf.Clamp (pointPosition.x, -maxWidth, maxWidth);
		Vector3 targetPosition = new Vector3 (targetPositionWidth, defender.position.y, 0.0f);

		Vector3 currentPosition = new Vector3 (defender.position.x, defender.position.y, 0.0f);

		//don't normalise, we want to defender to coast in to the destination position
		Vector3 direction = (targetPosition - currentPosition);
		defender.MovePosition (currentPosition + direction * maxSpeed * Time.deltaTime);
	}
}
