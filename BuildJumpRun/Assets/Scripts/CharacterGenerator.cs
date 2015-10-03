using UnityEngine;
using System.Collections;

public class CharacterGenerator : MonoBehaviour 
{
	public Sprite[] publicBodySprites;
	public Sprite[] publicHeadSprites;
	public Sprite[] publicTorsoSprites;
	public Sprite[] publicTrousersSprites;

	private Sprite[] bodySprites;
	public GameObject headObject;
	public GameObject torsoObject;
	public GameObject trousersObject;

	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		Generate ();
	}
	
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Update () 
	{
	
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void Generate () 
	{
		GenerateBody ();
		GenerateHead ();
		GenerateTorso ();
		GenerateTrousers ();
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void GenerateBody ()
	{
		int spriteIndex = Random.Range (0, publicBodySprites.Length);
		if (spriteIndex % 2 != 0) 
		{
			spriteIndex++;
		}

		if (spriteIndex >= publicBodySprites.Length) 
		{
			spriteIndex = 0;
		}

		bodySprites = new Sprite[2];
		bodySprites [0] = publicBodySprites [spriteIndex];
		bodySprites [1] = publicBodySprites [spriteIndex + 1];

		gameObject.GetComponent<SpriteRenderer> ().sprite = bodySprites [0];
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void GenerateHead ()
	{
		int spriteIndex = Random.Range (0, publicHeadSprites.Length);
		
		if (spriteIndex >= publicHeadSprites.Length) 
		{
			spriteIndex = 0;
		}

		headObject.GetComponent<SpriteRenderer> ().sprite = publicHeadSprites [spriteIndex];
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void GenerateTorso ()
	{
		int spriteIndex = Random.Range (0, publicTorsoSprites.Length);
		
		if (spriteIndex >= publicTorsoSprites.Length) 
		{
			spriteIndex = 0;
		}
		
		torsoObject.GetComponent<SpriteRenderer> ().sprite = publicTorsoSprites [spriteIndex];	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void GenerateTrousers ()
	{
		int spriteIndex = Random.Range (0, publicTrousersSprites.Length);
		
		if (spriteIndex >= publicTrousersSprites.Length) 
		{
			spriteIndex = 0;
		}
		
		trousersObject.GetComponent<SpriteRenderer> ().sprite = publicTrousersSprites [spriteIndex];	}
}
