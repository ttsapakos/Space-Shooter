using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject asteroid;
	public GameObject enemy;
	public GameObject powerUp;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start() 
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if(restart)
		{
			if(Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves() 
	{
		yield return new WaitForSeconds(startWait);
		
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Vector3 enemySpawn = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				Instantiate (enemy, enemySpawn, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait);
			}

			Vector3 powerUpPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion powerUpRotation = Quaternion.identity;

			Instantiate (powerUp, powerUpPosition, powerUpRotation);
			yield return new WaitForSeconds (waveWait);
			hazardCount++;

			if(gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}




