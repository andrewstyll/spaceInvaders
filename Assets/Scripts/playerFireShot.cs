using UnityEngine;
using System.Collections;

public class playerFireShot : MonoBehaviour {

	public GameObject shot;
	public float speed;

	public float shotCoolDown;

	private float deltaLastShot = 0.0f;

	// Use this for initialization
	void Start () {
		if (shotCoolDown == 0.0f) {
			shotCoolDown = 0.5f;
		}

		if (speed == 0.0f) {
			speed = 3.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		deltaLastShot += Time.deltaTime;

		if (Input.GetButton ("Fire1")) {
			if (deltaLastShot >= shotCoolDown) {
			
				GameObject shotInstance = Instantiate (shot, transform.position, Quaternion.identity) as GameObject;
				shotBehaviour script = shotInstance.GetComponent<shotBehaviour> ();
				script.speed = 3;
				script.target = "invader";
				deltaLastShot = 0.0f;
			}
		}
	}
}
