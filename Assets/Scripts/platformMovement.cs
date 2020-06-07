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
		//rb.transform.position.x = rb.transform.position.x;

		rb.MovePosition (rb.position + Vector2.left * Time.fixedDeltaTime * speed);
	}
}
