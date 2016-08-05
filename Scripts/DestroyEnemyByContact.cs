using UnityEngine;
using System.Collections;

public class DestroyEnemyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject enemyExplosion;
	public GameObject playerExplosion;
	public int scoreValue;
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
		
		Instantiate(enemyExplosion, transform.position, transform.rotation);
		
		if(other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		} else {
			Instantiate(explosion, other.transform.position, other.transform.rotation);
		}
		gameController.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
