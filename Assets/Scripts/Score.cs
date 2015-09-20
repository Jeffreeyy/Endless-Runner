using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private bool _isUpdatingScore = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ScoreCounter ();
		Debug.Log (Player.score);
	}

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

	IEnumerator ScoreTimer()
	{
		yield return new WaitForSeconds (1);
		Player.score ++;
	}
}
