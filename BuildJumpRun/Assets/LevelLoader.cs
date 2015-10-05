using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	public GameObject startUI;

	public GameObject startDoor;

	public GameObject scoreController;

	public GameObject[] enemySpawners;

	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start()
	{
		startDoor.GetComponent<CitizenSpawner> ().SetDoorLocked(true);
		
		foreach (GameObject enemySpawner in enemySpawners) 
		{
			enemySpawner.GetComponent<EnemySpawner>().SetDoorLocked(true);
		}
		
		scoreController.GetComponent<ScoreController> ().SetActive(false);
		
		startUI.SetActive (true);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void OnClickLoad()
	{
		Application.LoadLevel(0);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void OnClickStart()
	{
		startDoor.GetComponent<CitizenSpawner> ().SetDoorLocked(false);

		foreach (GameObject enemySpawner in enemySpawners) 
		{
			enemySpawner.GetComponent<EnemySpawner>().SetDoorLocked(false);
		}

		scoreController.GetComponent<ScoreController> ().SetActive(true);

		startUI.SetActive (false);

	}
}
