using UnityEngine;
using System.Collections;

public class CitizenSpawner : MonoBehaviour 
{
	public GameObject CitizenGameObject;

	public float spawnTimer = 3.0f;
	public float minimumSpawnTimer = 1.0f;
	public float timerDecrementAmount = 0.15f;
	public float startCitizenSpeed = 1.5f;

	private float timer = 0.0f; 
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () {
	
	}
	
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update () 
	{
		timer += Time.deltaTime;

		if (timer >= spawnTimer) 
		{
			ResetTimer();
			Spawn();

		}
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void Spawn () 
	{
		GameObject newCitizen = Instantiate<GameObject> (CitizenGameObject);
		newCitizen.transform.position = this.transform.position;
		//TODO: Animate Door
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void ResetTimer () 
	{
		timer = 0.0f;
		if (spawnTimer > minimumSpawnTimer) 
		{
			spawnTimer -= timerDecrementAmount;
		}
	}
}
