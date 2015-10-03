using UnityEngine;
using System.Collections;

public class CitizenController : MonoBehaviour 
{
	public float movementSpeed = -1.0f;

	private bool acquiredLoot = false;

	public GameObject particleEmitterPrefab;
	
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
		GameObject particleEmitter = Instantiate<GameObject> (particleEmitterPrefab);
		particleEmitter.transform.position = gameObject.transform.position;
		//TODO: PlayParticleEffect
		//TODO: NotifyScoreController
		Destroy (gameObject);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void CollectLoot()
	{
		acquiredLoot = true;
		//TODO: PlayCollectParticleEffect
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void OnCollisionEnter2D(Collision2D in_object)
	{
		if (in_object.gameObject.tag == "Enemy" || in_object.gameObject.tag == "StaticHazard") 
		{
			this.DestroyObject();
		}
		else if (in_object.gameObject.tag == "Loot") 
		{
			this.CollectLoot();
		}
	}
}
