using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private bool touchingPlatform = false;
	public float jumpVelocity = 5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space) && touchingPlatform == true) {
			rb.velocity = Vector2.up * jumpVelocity;
			touchingPlatform = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collidedObject) {
		if (collidedObject.gameObject.tag == "platform") {
			touchingPlatform = true;
		}
	}
}
