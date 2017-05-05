using UnityEngine;
using System.Collections;

public class invaderBehaviour : MonoBehaviour {

	//store a reference to the two sprites to allow switching between the two
	public Sprite position_1;
	public Sprite position_2;

	private SpriteRenderer spriteRenderer;
	public float invaderWidth;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		if(spriteRenderer.sprite == null) {
			spriteRenderer.sprite = position_1;
		}
		invaderWidth = GetComponent<Renderer> ().bounds.extents.x * 2f;
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public void changeSprite() {
		
		if (spriteRenderer.sprite == position_1) {
			spriteRenderer.sprite = position_2;
		} else {
			spriteRenderer.sprite = position_1;	
		}
	}
		
	//move invader left or right
	public bool move(float leftWall, float rightWall, float speed, bool moveRight) {
		Vector3 invaderPosition = transform.position;
		float leftMax = leftWall + invaderWidth;
		float rightMax = rightWall - invaderWidth;

		if (moveRight) {
			invaderPosition.x += speed * Time.deltaTime;
		} else {
			invaderPosition.x -= speed * Time.deltaTime;
		}
			
		transform.position = invaderPosition;
		changeSprite ();

		if (transform.position.x > rightMax || transform.position.x < leftMax) {
			return true;
		} else {
			return false;
		}
	}

	public void drop(float dropStep) {
		Vector3 invaderPosition = transform.position;
		invaderPosition.y -= dropStep * Time.deltaTime;
		transform.position = invaderPosition;
		changeSprite ();
	}
}