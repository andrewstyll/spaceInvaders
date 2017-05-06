using UnityEngine;
using System.Collections;

public class shotBehaviour : MonoBehaviour {

	public float speed;
	public string target;

	private Rigidbody2D shot;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		if (speed == 0.0f) {
			speed = 3.0f;
		}
		shot = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		shot.velocity = new Vector2 (0.0f, speed);
		flipBulletSprite ();
	}

	// flip the bullet quickly to animate
	void flipBulletSprite() {
		spriteRenderer.flipY = !spriteRenderer.flipY;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag ("shot")) {
			Destroy (gameObject);
		}
	}
}
