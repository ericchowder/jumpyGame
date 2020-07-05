using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

	// GameObject variables
	private Rigidbody2D rb;
	public GameObject loserMenuUI;
	public Animator animator;

	// Script variables
	private Vector2 pos;
	private bool touchingPlatform = false;
	public float jumpVelocity = 5f;

	void Start () {
		// Gets native GameObject's rigidbody
		rb = GetComponent<Rigidbody2D> ();	
		// On entry initiate playerJump animation to false be default
		animator.SetBool ("playerJump", false);
	}

	void FixedUpdate () {
		// jumping functoin (only jumps when touching platform)
		if (Input.GetKeyDown (KeyCode.Space) && touchingPlatform == true) {
			rb.velocity = Vector2.up * jumpVelocity;
			// touchingPlatform to false to disable multi-jump
			touchingPlatform = false;
			animator.SetBool ("playerJump", true);
		}

		// fixes x position of player unless below platform level
		pos = transform.position;
		if (transform.position.y >= -4) {
			// won't let me modify transform.position directly
			pos.x = -2;
			transform.position = pos;
		}

		// when player below viewable screen, losing menu appears
		if (transform.position.y < -6) {
			loserMenuUI.SetActive (true);
		}

		Debug.Log ("Current Time is: " + Time.time);
	}

	// checks if collided (touching) platform
	void OnCollisionEnter2D(Collision2D collidedObject) {
		if (collidedObject.gameObject.tag == "platform") {
			touchingPlatform = true;
			animator.SetBool ("playerJump", false);
		}
	}
}
