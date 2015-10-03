using UnityEngine;
using System.Collections;

public class LootController : MonoBehaviour 
{
	public Sprite[] publicLootSprites;

	public float maxLifeTimer = 1.5f;

	private float timer = 1.5f;

	public GameObject particleEmitterPrefab;
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		int spriteIndex = Random.Range (0, publicLootSprites.Length);
		
		gameObject.GetComponent<SpriteRenderer> ().sprite = publicLootSprites[spriteIndex];

		timer = maxLifeTimer;
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0.0f) 
		{
			DestroyObject();
		}
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
	void OnCollisionEnter2D(Collision2D in_object)
	{
		if (in_object.gameObject.tag == "Enemy" || in_object.gameObject.tag == "Citizen") 
		{
			this.DestroyObject();
		}
	}
}
