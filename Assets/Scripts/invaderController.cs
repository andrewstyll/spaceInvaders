using UnityEngine;
using System.Collections;

// the purpose of this script is to primarily keep track fo all instances of objects 

public class invaderController : MonoBehaviour {

	//define camera to control bounds of window
	public Camera cam;

	public GameObject invader_1;
	public GameObject invader_2;
	public GameObject invader_3;

	public float deltaMove; //time between each move 
	public float dropStep; //amount an invader drops at once

	private float invaderSpeed; //amount an invader moves per step
	private float deltaLastMoved = 0.0f;

	private bool invaderMoveRight = true;
	private bool invaderMoveDown = false;

	private int MAX_ROWS = 5;
	private int MAX_COLUMNS = 11;

	private float maxWidth;
	public float ceiling;

	public float spacingX;
	public float spacingY;

	private GameObject[,] invaders;
	private invaderBehaviour[,] invaderScripts;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		Vector3 maxCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 maxCornerW = cam.ScreenToWorldPoint(maxCorner);
		maxWidth = maxCornerW.x;

		GameObject invader;
		invaders = new GameObject[MAX_ROWS, MAX_COLUMNS];
		invaderScripts = new invaderBehaviour[MAX_ROWS, MAX_COLUMNS];

		invaderMoveRight = true;
		invaderMoveDown = false;

		float startPositionX = -maxWidth/1.2f;
		float starPositionY = ceiling;

		// make this a function of the screen size so that it is consistent proportionally 
		// across all screen sizes
		invaderSpeed = maxWidth*2;

		for (int i = 0; i < MAX_ROWS; i++) {
			
			if (i == 0) {
				invader = invader_1;
			} else if (i > 0 && i < 3) {
				invader = invader_2;
			} else {
				invader = invader_3;
			}

			for (int j = 0; j < MAX_COLUMNS; j++) {
				Vector3 position = new Vector3 (startPositionX+spacingX*j, starPositionY+spacingY*i, 0.0f);
				invaders[i, j] = Instantiate (invader, position, Quaternion.identity) as GameObject;
				invaderScripts[i, j] = invaders [i, j].GetComponent<invaderBehaviour> ();

				if (i % 2 == 0) {
					SpriteRenderer invaderSpriteRenderer = invaders [i, j].GetComponent<SpriteRenderer> ();
					Sprite newStartPostion = invaderScripts[i, j].position_2;
					invaderSpriteRenderer.sprite = newStartPostion;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//every x amount of time, move
		deltaLastMoved += Time.deltaTime;

		if(deltaLastMoved > deltaMove ) {
			deltaLastMoved -= deltaMove;

			if (invaderMoveDown) {
				invaderMoveDown = false;
				deltaMove = Mathf.Min (deltaMove*0.9f, deltaMove);
				dropInvaders ();
			} else {
				moveInvaders ();
			}
		}
	}

	void moveInvaders() {
		bool flip = false;

		for (int i = 0; i < MAX_ROWS; i++) {
			
			for (int j = 0; j < MAX_COLUMNS; j++) {

				if (invaders [i, j] != null) {
					bool retVal = invaderScripts[i, j].move (-maxWidth, maxWidth, invaderSpeed, invaderMoveRight);

					if (flip == false && retVal == true) {
						flip = true;
					}
				}
			}
		}
		if (flip) {
			invaderMoveDown = true;
			invaderMoveRight = !invaderMoveRight;
		}
	}

	void dropInvaders() {
		for (int i = 0; i < MAX_ROWS; i++) {

			for (int j = 0; j < MAX_COLUMNS; j++) {
				invaderScripts[i, j].drop (dropStep);
			}
		}
	}
}