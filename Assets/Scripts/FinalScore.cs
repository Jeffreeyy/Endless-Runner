using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public Text finalScoreText;

	// Use this for initialization
	void Start () {
		UpdateUI ();
	}
	
	// Update is called once per frame
	void UpdateUI () {
		finalScoreText.text = "Your score is: " + Player.score + " sec";
	}
}
