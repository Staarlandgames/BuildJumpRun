using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	//Prefab for citizen
	public GameObject EnemyGameObject;

	//Const variables
	public float maxSpawnTimer = 10.0f;
	public float speedMultiplier = -1.0f;
	public float minimumSpawnTimer = 3.0f;
	public float timerDecrementAmount = 0.15f;
	public float maxEnemySpeed = 2.0f;
	public float minEnemySpeed = 1.5f;
	public bool overrideLock = false;

	public int chanceLoot = 50;
	
	public Sprite[] doorOpenSprites;

	//Timers
	private float spawnTimer = 3.0f;
	private float timer = 0.0f; 
	private float doorAnimationTimer = 0.0f; 

	//control variables
	private int doorIndex = 0;
	private float enemySpeed = 1.5f;

	private bool locked = true;
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		//Setup Timer
		spawnTimer = maxSpawnTimer;

		//setup speed
		enemySpeed = maxEnemySpeed;

		//Pick Random Door
		doorIndex = Random.Range (0, doorOpenSprites.Length - 1);

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
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void Spawn () 
	{
		GameObject newEnemy = Instantiate<GameObject> (EnemyGameObject);
		newEnemy.transform.position = this.transform.position;

		enemySpeed = Random.Range (minEnemySpeed, maxEnemySpeed);

		int rand = Random.Range (0, 100);

		//Set CitizenSpeed
		newEnemy.GetComponent<EnemyController> ().SetMovementSpeed (enemySpeed * speedMultiplier);

		if (rand > chanceLoot) 
		{
			newEnemy.GetComponent<EnemyController> ().HasLoot();
		}

		GetComponentInChildren<AudioSource> ().Play();
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
	}
}
