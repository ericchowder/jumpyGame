using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {

	private Rigidbody2D rb;

	public float speed = 5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Playform movement/posiiton based on speed
		rb.MovePosition (rb.position + Vector2.left * Time.fixedDeltaTime * speed);

		// Destroys platform instance when out of screen
		if (transform.position.x < -30) {
			Destroy (gameObject);
		}
	}
}
