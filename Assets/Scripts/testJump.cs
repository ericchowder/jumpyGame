using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testJump : MonoBehaviour {

	// GameObject variables
	private Rigidbody2D rb;
	private BoxCollider2D boxCollider2d;
	[SerializeField] private LayerMask platformsLayerMask;
	public GameObject loserMenuUI;
	public Animator animator;

	// Script variables
	private Vector2 pos;
	public float jumpVelocity = 5f;

	// Use this for initialization
	void Awake () {
		// Gets native GameObject's rigidbody
		rb = GetComponent<Rigidbody2D>();	
		// Gets native GameObject's boxcollider
		boxCollider2d = GetComponent<BoxCollider2D>();
		// On entry initiate playerJump animation to false be default
		animator.SetBool("playerJump", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Check if player is touching ground
		if (isGrounded ()) {
			// running anim if player on ground
			animator.SetBool ("playerJump", false);
			if (Input.GetKeyDown (KeyCode.Space)) {
				// jump w/anim if user hits space bar
				rb.velocity = Vector2.up * jumpVelocity;
				animator.SetBool ("playerJump", true);
			}
		}

		Debug.Log ("is grounded: " + isGrounded());
	}

	bool isGrounded() {
		// Boxcast(origin, size, angle, direction, distance, collisionObject)
		RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, 
			boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
		// If true, means raycast hit the ground
		return raycastHit2d.collider != null;
	}
}
