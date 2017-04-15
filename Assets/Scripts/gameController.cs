using UnityEngine;
using System.Collections;

// the purpose of this script is to primarily keep track fo all instances of objects 
// in the game :D

public class gameController : MonoBehaviour {

	public GameObject invader_1;
	public GameObject invader_2;
	public GameObject invader_3;

	public float deltaMove;
	public float invaderSpeed; //amount an invader moves per step
	public float dropStep; //amount an invader drops at once

	private float deltaLastMoved;
	private bool invaderMoveRight;
	private bool invaderMoveDown;

	//linked list would be better
	private int MAX_ROWS = 5;
	private int MAX_COLUMNS = 11;

	public float leftEdge;
	public float rightEdge;
	public float ceiling;

	public float spacingX;
	public float spacingY;

	private GameObject[,] invaders;
	private invaderBehaviour invaderScript;

	// Use this for initialization
	void Start () {
		invaderMoveRight = true;
		invaderMoveDown = false;

		deltaLastMoved = 0.0f;

		GameObject invader;
		invaders = new GameObject[MAX_ROWS, MAX_COLUMNS];

		float startPositionX = leftEdge;
		float starPositionY = ceiling;

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
				Quaternion rotation = Quaternion.identity;
				invaders[i, j] = (GameObject)Instantiate (invader, position, rotation);
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
				invaderScript = invaders [i, j].GetComponent<invaderBehaviour> ();
				bool retVal = invaderScript.move (leftEdge, rightEdge, invaderSpeed, invaderMoveRight);

				if (flip == false && retVal == true) {
					flip = true;
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
				invaderScript = invaders [i, j].GetComponent<invaderBehaviour> ();
				invaderScript.drop (dropStep);
			}
		}
	}
}