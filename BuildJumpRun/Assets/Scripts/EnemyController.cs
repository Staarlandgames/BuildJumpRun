using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public float movementSpeed = -1.0f;

	private bool hasLoot = false;

	public GameObject particleEmitterPrefab;
	public GameObject lootObject;

	public Collider collider;

	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update () 
	{
		Vector2 position = new Vector2 (10000.0f, 100000.0f);
		bool changed = false;
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			changed = true;
			position = Input.GetTouch (0).position;
		} 
		else if (Input.GetMouseButtonDown(0))
		{
			changed = true;
			position = Input.mousePosition;
		}

		if (!changed) 
		{
			return;
		}

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100000);
		if(hit.collider != null)
		{
			if(hit.collider.gameObject == this.gameObject)
			{
				this.DestroyObject();
			}
		}
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
		GameObject particleEmitter = Instantiate<GameObject> (particleEmitterPrefab);
		particleEmitter.transform.position = gameObject.transform.position;

		if (hasLoot) 
		{
			GameObject loot = Instantiate<GameObject> (lootObject);
			loot.transform.position = gameObject.transform.position;
		}
		Destroy(gameObject);
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
