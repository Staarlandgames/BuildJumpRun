using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour 
{
	public GameObject scoreUI;
	public GameObject livesUI;
	public GameObject endGameUI;

	public int startingLives = 10;

	private int score = 0;
	private int lives = 10;

	private GameObject[] citizenSpawns;
	private GameObject[] enemySpawns;

	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		citizenSpawns = GameObject.FindGameObjectsWithTag ("CitizenSpawner");
		enemySpawns = GameObject.FindGameObjectsWithTag ("EnemySpawner");
		lives = startingLives +1;
		RemoveLives();
		AddScore (0);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void RemoveLives()
	{
		lives--;
		livesUI.GetComponent<Text> ().text = "X " + lives.ToString();
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void AddScore(int in_score)
	{
		score += in_score;
		scoreUI.GetComponent<Text> ().text = score.ToString("d6");
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update()
	{
		if (lives <= 0) 
		{
			//Disable spawners
			DisableSpawners();
			//Show end of game UI
			endGameUI.SetActive(true);
		}
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void DisableSpawners()
	{
		foreach (var citizen in citizenSpawns) 
		{
			citizen.GetComponent<CitizenSpawner>().SetDoorLocked(true);
		}

		foreach (var enemy in enemySpawns) 
		{
			enemy.GetComponent<EnemySpawner>().SetDoorLocked(true);
		}
	}

}
