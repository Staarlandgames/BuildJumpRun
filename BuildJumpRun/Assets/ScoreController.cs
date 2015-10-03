using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour 
{
	public GameObject scoreUI;
	public GameObject livesUI;

	public int startingLives = 10;

	private int score = 0;
	private int lives = 10;

	//---------------------------------------------------------
	//---------------------------------------------------------
	void Start () 
	{
		lives = startingLives;
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void RemoveLives()
	{
		lives--;
		livesUI.GetComponent<Text> ().text = "X " + lives.ToString();
	}
	//---------------------------------------------------------
	//---------------------------------------------------------
	public void AddScore(int in_score)
	{
		score += in_score;
		scoreUI.GetComponent<Text> ().text = score.ToString();
	}
}
