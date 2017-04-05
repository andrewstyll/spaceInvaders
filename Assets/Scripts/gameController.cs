using UnityEngine;
using System.Collections;

// the purpose of this script is to primarily keep track fo all instances of objects 
// in the game :D

public class gameController : MonoBehaviour {

	public GameObject invader_1;
	public GameObject invader_2;
	public GameObject invader_3;

	//linked list would be better
	private int MAX_ROWS = 1;
	private int MAX_COLUMNS = 11;
	private Object[,] invaders;

	// Use this for initialization
	void Start () {
		invaders = new Object[MAX_ROWS, MAX_COLUMNS];

		for (int i = 0; i < MAX_ROWS; i++) {
			for (int j = 0; i < MAX_COLUMNS; j++) {
				Vector3 position = new Vector3 (0.0f, 0.0f, 0.0f);
				Quaternion rotation = Quaternion.identity;
				invaders[i, j] = Instantiate (invader_1, position, rotation);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
