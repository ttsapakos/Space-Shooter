using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour 
{
	private GameController gameController;
	private PlayerController playerController;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		} else {
			Debug.Log ("Cannot find 'GameController' script");
		}
		
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null) {
			playerController = playerControllerObject.GetComponent<PlayerController>();
		} else {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary") {
			return;
		}
		
		if(other.tag == "Player") {
			playerController.ChangeFireRate();
			Destroy(gameObject);
		}
	}
}
