using UnityEngine;
using System.Collections;

public class invaderFireShot : MonoBehaviour {

	public float coolDownMin;
	public float coolDownMax;
	public float shotSpeed;

	public GameObject shot;

	private string target;
	private float shotCoolDown;
	private float deltaLastShot;

	private GameObject[] allInvaders;

	// Use this for initialization
	void Start () {
		if(coolDownMin <= 0) {
			coolDownMin = 0.7f;
		}

		if(coolDownMax <= 0) {
			coolDownMax = 1.3f;
		}

		if (shotSpeed >= 0.0f) {
			shotSpeed = -3.0f;
		}

		deltaLastShot = 0.0f;
		target = "Player";
		UpdateShotCoolDown ();
	}
	
	// Update is called once per frame
	void Update () {
		deltaLastShot += Time.deltaTime;

		if (deltaLastShot >= shotCoolDown) {
			Fire ();
			UpdateShotCoolDown ();
		}
	}

	//grab a random invader every x seconds and fire a normal shot downwards
	private GameObject getInvader() {
		allInvaders = GameObject.FindGameObjectsWithTag("invader");

		if (allInvaders.Length != 0) {
			return allInvaders [(int)Random.Range (0.0f, allInvaders.Length - 1)];
		} else {
			return null;
		}
	}

	private void Fire() {
		GameObject invader = getInvader ();
		GameObject shotInstance = Instantiate (shot, invader.transform.position, Quaternion.identity) as GameObject;
		shotBehaviour script = shotInstance.GetComponent<shotBehaviour> ();
		script.speed = shotSpeed;
		script.target = target;
		deltaLastShot = 0.0f;
	}

	private void UpdateShotCoolDown() {
		shotCoolDown = Random.Range (coolDownMin, coolDownMax);
	}
}