using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	//Play the game
	public void PlayGame ()
	{
		AutoFade.LoadLevel("game" ,1,1,Color.white);
	}
	//How to play the game
	public void HowToPlayGame()
	{
		Application.LoadLevel("howtoplay");
	}
	//Quit the game
	public void QuitGame()
	{
		Application.Quit ();
	}

	public void Update()
	{
		//Able to press escape in different scenes
		if (Input.GetKey(KeyCode.Escape) & (Application.loadedLevelName == "game" || Application.loadedLevelName == "gameover" || Application.loadedLevelName == "howtoplay"))
		{
			Application.LoadLevel("menu");
		}
		//Respawn
		if (Input.GetKey(KeyCode.R) & Application.loadedLevelName == "gameover")
		{
			AutoFade.LoadLevel("game" ,0.5f,0.5f,Color.white);
		}
	}
}
