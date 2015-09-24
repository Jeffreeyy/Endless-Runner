using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
    private bool _isUpdatingScore = true;
    private float _secondsDelay = 1f;

	void Update () {
		ScoreCounter ();
		UpdateUI ();
	}

	//Counts the score and calls the delay
	private void ScoreCounter()
	{
		if(_isUpdatingScore == true)
		{
			_isUpdatingScore = false;
			ScoreDelay ();
		}

	}

	private void ScoreDelay()
	{
		StartCoroutine (ScoreTimer ());
	}

	void UpdateUI ()
	{
		scoreText.text = "Time Survived: " + Player.score + " sec";
	}

	IEnumerator ScoreTimer()
	{
		yield return new WaitForSeconds (_secondsDelay);
		Player.score ++;
		ChunkManager.moveSpeed += 0.2f;
        _isUpdatingScore = true;
	}
}
