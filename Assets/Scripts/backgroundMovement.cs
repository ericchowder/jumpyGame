using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed = 5f;
	//GameObject gameobject;

	Vector2 start_pos = new Vector2(18.04f ,-0.014f);

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		//rb.MovePosition (start_pos * Time.fixedDeltaTime * speed);
		gameObject.transform.position = start_pos;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		// Playform movement/posiiton based on speed
		rb.MovePosition(rb.position + Vector2.left * Time.fixedDeltaTime * speed);

		// Destroys platform instance when out of screen
		if (transform.position.x < -30) {
			Destroy(gameObject);
		}
	}
}
