using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public float movementSpeed = -1.0f;

	private bool hasLoot = false;
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
		position.x += movementSpeed * Time.deltaTime;
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
		Destroy (gameObject);
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void HasLoot()
	{
		hasLoot = true;
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void OnCollisionEnter2D(Collision2D in_object)
	{
		if (in_object.gameObject.tag == "Wall") 
		{
			this.DestroyObject();
		}
	}
}
