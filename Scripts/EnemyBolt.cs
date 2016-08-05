using UnityEngine;
using System.Collections;

public class EnemyBolt : MonoBehaviour {

	public GameObject playerExplosion;
	private GameController gameController;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		} else {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary" || other.tag == "Power Up") {
			return;
		}

		if(other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
			
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
