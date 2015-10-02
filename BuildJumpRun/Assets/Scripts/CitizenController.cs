using UnityEngine;
using System.Collections;

public class CitizenController : MonoBehaviour 
{
	public float movementSpeed = -1.0f;

	private bool acquiredLoot = false;
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		
	}
	
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update () 
	{
		
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
		//TODO: PlayParticleEffect
		//TODO: NotifyScoreController
		Destroy (this);
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
	void OnCollisionEnter(Collision in_object)
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
