using UnityEngine;
using System.Collections;

public class CitizenController : MonoBehaviour 
{
	public float movementSpeed = -1.0f;

	private bool acquiredLoot = false;

	public GameObject deathParticleEmitterPrefab;
	public GameObject lootParticleEmitterPrefab;
	public GameObject successParticleEmitterPrefab;

	private GameObject scoreController;

	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		scoreController = GameObject.FindGameObjectWithTag ("ScoreController");
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void FixedUpdate () 
	{
		var position = this.gameObject.transform.position;
		position.y += movementSpeed * Time.deltaTime;
		this.gameObject.transform.position = position;
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void SetMovementSpeed (float in_movementSpeed) 
	{
		movementSpeed = in_movementSpeed;
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void DestroyObject()
	{
		GameObject particleEmitter = Instantiate<GameObject> (deathParticleEmitterPrefab);
		particleEmitter.transform.position = gameObject.transform.position;
		Destroy (gameObject);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void CollectLoot()
	{
		Debug.Log ("Has Loot");
		acquiredLoot = true;
		GameObject particleEmitter = Instantiate<GameObject> (deathParticleEmitterPrefab);
		particleEmitter.transform.position = gameObject.transform.position;
		scoreController.GetComponent<ScoreController> ().AddScore(10);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void Score()
	{
		var controller = scoreController.GetComponent<ScoreController> ();

		controller.AddScore(10);

		if (acquiredLoot) 
		{
			controller.AddScore(10);
		}

		GameObject particleEmitter = Instantiate<GameObject> (successParticleEmitterPrefab);
		particleEmitter.transform.position = gameObject.transform.position;

		Destroy (gameObject);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void OnCollisionEnter2D(Collision2D in_object)
	{
		if (in_object.gameObject.tag == "Enemy" || in_object.gameObject.tag == "StaticHazard") 
		{
			var controller = scoreController.GetComponent<ScoreController> ();
			
			controller.RemoveLives();
			this.DestroyObject();
		}
		else if (in_object.gameObject.tag == "Loot") 
		{
			this.CollectLoot();
		}
		else if (in_object.gameObject.tag == "Wall") 
		{
			this.Score();
		}
	}
}
