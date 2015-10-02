using UnityEngine;
using System.Collections;

public class CharacterGenerator : MonoBehaviour 
{
	public Sprite[] publicBodySprites;
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

		ApplySprites ();
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
		//TODO: Select Sprites
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void GenerateTorso ()
	{
		//TODO: Select Sprites
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void GenerateTrousers ()
	{
		//TODO: Select Sprites
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	void ApplySprites ()
	{

	}
}
