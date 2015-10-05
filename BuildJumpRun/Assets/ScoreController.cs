using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour 
{
	public GameObject scoreUI;
	public GameObject livesUI;
	public GameObject endGameUI;

	public GameObject doorOne;
	public GameObject doorThree;

	public float doorOneTimer = 30.0f; //Seconds
	public int doorThreeScore = 100;

	private bool doorOneOpen = false;
	private bool doorThreeOpen = false;

	public int startingLives = 10;

	private int score = 0;
	private int lives = 10;

	private bool active = false;

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
	public void SetActive(bool in_active)
	{
		active = in_active;
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void RemoveLives()
	{
		if (!active) 
		{
			return;
		}
		lives--;
		livesUI.GetComponent<Text> ().text = "X " + lives.ToString();
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void AddScore(int in_score)
	{
		if (!active) 
		{
			return;
		}
		score += in_score;
		scoreUI.GetComponent<Text> ().text = score.ToString("d6");
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update()
	{
		if (!active) 
		{
			return;
		}
		if (lives <= 0) 
		{
			//Disable spawners
			DisableSpawners();
			//Show end of game UI
			endGameUI.SetActive(true);
			active = false;
		}

		if (!doorOneOpen) 
		{
			doorOneTimer -= Time.deltaTime;
			if(doorOneTimer <= 0.0f)
			{
				doorOne.GetComponent<CitizenSpawner>().SetDoorLocked(false);
				doorOneOpen = true;
			}
		}
		if (!doorThreeOpen) 
		{
			if(score > doorThreeScore)
			{
				doorThree.GetComponent<CitizenSpawner>().SetDoorLocked(false);
				doorThreeOpen = true;
			}
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
