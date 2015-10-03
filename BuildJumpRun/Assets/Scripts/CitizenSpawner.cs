using UnityEngine;
using System.Collections;

public class CitizenSpawner : MonoBehaviour 
{
	//Prefab for citizen
	public GameObject CitizenGameObject;

	//Const variables
	public float maxSpawnTimer = 3.0f;
	public float doorTimer = 0.25f;
	public float minimumSpawnTimer = 1.25f;
	public float timerDecrementAmount = 0.15f;
	public float maxCitizenSpeed = 1.5f;
	public float minCitizenSpeed = 1.0f;
	public float speedDecrementAmount = 0.05f;
	public bool overrideLock = false;

	public Sprite[] doorClosedSprites;
	public Sprite[] doorOpenSprites;
	public Sprite[] doorLockedSprites;

	//Timers
	private float spawnTimer = 3.0f;
	private float timer = 0.0f; 
	private float doorAnimationTimer = 0.0f; 

	//control variables
	private int doorIndex = 0;
	private float citizenSpeed = 1.5f;

	private bool locked = true;
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		//Setup Timer
		spawnTimer = maxSpawnTimer;

		//setup speed
		citizenSpeed = maxCitizenSpeed;

		//Pick Random Door
		doorIndex = Random.Range (0, doorClosedSprites.Length - 1);

		if (overrideLock) 
		{
			doorIndex = 2;
		}
		//set locked 
		SetDoorLocked(!overrideLock);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void SetDoorSprite (Sprite in_sprite) 
	{
		this.GetComponent<SpriteRenderer> ().sprite = in_sprite;
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void SetDoorLocked (bool in_locked) 
	{
		locked = in_locked;

		if (locked) 
		{
			SetDoorSprite(doorLockedSprites[doorIndex]);
		} 
		else 
		{
			SetDoorSprite(doorClosedSprites[doorIndex]);
		}
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update () 
	{
		if (locked) 
		{
			return;
		}

		timer += Time.deltaTime;
		doorAnimationTimer += Time.deltaTime;

		if (timer >= spawnTimer) 
		{
			ResetTimer();
			Spawn();
		}

		if (doorAnimationTimer >= doorTimer) 
		{
			SetDoorSprite(doorClosedSprites[doorIndex]);
			doorAnimationTimer = 0.0f;
		}
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void Spawn () 
	{
		//Set Door Open
		SetDoorSprite(doorOpenSprites[doorIndex]);

		GameObject newCitizen = Instantiate<GameObject> (CitizenGameObject);
		newCitizen.transform.position = this.transform.position;

		//Set CitizenSpeed
		newCitizen.GetComponent<CitizenController> ().SetMovementSpeed (-citizenSpeed);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void ResetTimer () 
	{
		timer = 0.0f;
		doorAnimationTimer = 0.0f;
		if (spawnTimer > minimumSpawnTimer) 
		{
			spawnTimer -= timerDecrementAmount;
		}

		if (citizenSpeed > minCitizenSpeed) 
		{
			citizenSpeed -= speedDecrementAmount;
		}
	}
}
