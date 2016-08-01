using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelmanager;

	void Start() {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log ("Collision");
		
	}
	void OnTriggerEnter2D (Collider2D trigger) {
		Debug.Log ("Trigger");
		levelmanager.LoadLevel ("Lose");
	}
	
}
