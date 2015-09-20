using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	Text Meters;
    private bool _isUpdatingScore = true;
    private float _secondsDelay = 0.5f;
    private GUIStyle guiStyle = new GUIStyle();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ScoreCounter ();
		Debug.Log (Player.score);
	}

    void OnGUI()
    {
        guiStyle.fontSize = 20;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(1480, 33, 50, 10), "Meters: " + Player.score, guiStyle);
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
		yield return new WaitForSeconds (_secondsDelay);
		Player.score ++;
        _isUpdatingScore = true;
	}
}
