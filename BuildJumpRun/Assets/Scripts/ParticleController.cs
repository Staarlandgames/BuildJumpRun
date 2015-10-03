using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	public float maxLifeTimer = 1.5f;
	
	private float timer = 1.5f;

	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		timer = maxLifeTimer;
	}
	
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update () 
	{
		timer -= Time.deltaTime;
		
		if (timer <= 0.0f) 
		{
			Destroy(gameObject);
		}
	}
}
