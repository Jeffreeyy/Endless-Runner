using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public void PlayGame ()
	{
		AutoFade.LoadLevel("game" ,1,1,Color.white);
	}
	public void QuitGame()
	{
		Application.Quit ();
	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.Escape) & Application.loadedLevelName == "game")
		{
			Application.LoadLevel("menu");
		}

		if (Input.GetKey(KeyCode.R) & Application.loadedLevelName == "gameover")
		{
			AutoFade.LoadLevel("game" ,0.5f,0.5f,Color.white);
		}
	}
}
