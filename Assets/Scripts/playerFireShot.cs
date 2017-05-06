using UnityEngine;
using System.Collections;

public class playerFireShot : MonoBehaviour {

	public GameObject shot;
	public float shotSpeed;

	public float shotCoolDown;

	private float deltaLastShot;
	private string target;

	// Use this for initialization
	void Start () {
		if (shotCoolDown == 0.0f) {
			shotCoolDown = 0.5f;
		}

		if (shotSpeed == 0.0f || shotSpeed <= 0.0f) {
			shotSpeed = 3.0f;
		}
		//so we can immediatly fire a shot
		deltaLastShot = shotCoolDown;
		target = "invader";
	}
	
	// Update is called once per frame
	void Update () {
		
		deltaLastShot += Time.deltaTime;

		if (Input.GetButton ("Fire1")) {
			if (deltaLastShot >= shotCoolDown) {
				Fire ();
			}
		}
	}

	private void Fire() {
		GameObject shotInstance = Instantiate (shot, transform.position, Quaternion.identity) as GameObject;
		shotBehaviour script = shotInstance.GetComponent<shotBehaviour> ();
		script.speed = shotSpeed;
		script.target = target;
		deltaLastShot = 0.0f;
	}
}
