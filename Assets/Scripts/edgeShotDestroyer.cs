﻿using UnityEngine;
using System.Collections;

public class edgeShotDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		Destroy (col.gameObject);
	}
}
