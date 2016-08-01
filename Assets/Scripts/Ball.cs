using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relatie to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for mouse click to begin
			if (Input.GetMouseButtonDown(0)){
				Debug.Log("mouse clicked!");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		// Ball does not trigger when brick is destroyed, possibly
		// due to the brick being destroyed before auido is called?
		
		// Careful ball will always speed by, could pick a range with 0 mean?
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f),Random.Range(0f, 0.2f));
		
		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
	
}
