using UnityEngine;
using System.Collections;

public class LootController : MonoBehaviour 
{
	public Sprite[] publicLootSprites;

	public float maxLifeTimer = 1.5f;

	private float timer = 1.5f;
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
			//TODO: Play Audio
			Destroy(gameObject);
		}
	}
}
