using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

	// GameObject variables
	private Rigidbody2D rb;
	private BoxCollider2D boxCollider2d;
	[SerializeField] private LayerMask platformsLayerMask;
	public GameObject loserMenuUI;
	public Animator animator;

	// Script variables
	private Vector2 pos;
	//private bool touchingPlatform = false;
	public float jumpVelocity = 5f;


	void Start() {
		// Gets native GameObject's rigidbody
		rb = GetComponent<Rigidbody2D>();	
		// Gets native GameObject's boxcollider
		boxCollider2d = GetComponent<BoxCollider2D>();
		// On entry initiate playerJump animation to false be default
		animator.SetBool("playerJump", false);
	}


	void Update() {
		// new jump function
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
			rb.velocity = Vector2.up * jumpVelocity;
			// touchingPlatform to false to disable multi-jump
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
			loserMenuUI.SetActive(true);
		}
	}

	// Disable jump animation when player touching platform
	void OnCollisionEnter2D(Collision2D collidedObject) {
		if (collidedObject.gameObject.tag == "platform") {
			animator.SetBool("playerJump", false);
		}
	}


	// Check to see if player is grounded with raycast
	bool isGrounded() {
		// Boxcast(origin, size, angle, direction, distance)
		RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, 
			boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
		// If true, means raycast hit the ground
		return raycastHit2d.collider != null;
	}
}
