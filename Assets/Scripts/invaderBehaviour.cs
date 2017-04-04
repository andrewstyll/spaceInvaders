using UnityEngine;
using System.Collections;

public class invaderBehaviour : MonoBehaviour {

	//store a reference to the two sprites to allow switching between the two
	public Sprite position_1;
	public Sprite position_2;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if(spriteRenderer.sprite == null) {
			spriteRenderer.sprite = position_1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			changeSprite ();
		}
	}

	void changeSprite() {
		if (spriteRenderer.sprite == position_1) {
			spriteRenderer.sprite = position_2;
		} else {
			spriteRenderer.sprite = position_1;	
		}
	}
}
