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
	}
}
