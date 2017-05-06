using UnityEngine;
using System.Collections;

public class invaderDestroy : MonoBehaviour {

	public Sprite explosion;

	IEnumerator OnTriggerEnter2D(Collider2D collider) {
		shotBehaviour shotScript = collider.gameObject.GetComponent<shotBehaviour> ();

		if(gameObject.CompareTag(shotScript.target)) {
			Destroy (collider.gameObject);

			SpriteRenderer invaderRenderer = gameObject.GetComponent<SpriteRenderer> ();
			invaderRenderer.sprite = explosion;
			yield return new WaitForSeconds (0.2f);
			
			Destroy (gameObject);
		}
	}
}
