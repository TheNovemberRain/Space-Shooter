using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject asteroidExplosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject;

		gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} 
		else {
			Debug.Log("Connot find the 'GameController' script.");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}
		if (other.tag == "Player") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver ();
		} 
		else {
			Instantiate (asteroidExplosion, transform.position, transform.rotation);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
		gameController.AddScore (scoreValue);
	}
}
