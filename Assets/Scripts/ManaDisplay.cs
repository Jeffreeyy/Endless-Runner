using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaDisplay : MonoBehaviour {

	public Text manaText;

	void Update()
	{
		UpdateUI ();
		//Check how much mana the player has
		if(Player.mana == 300)
		{
			this.transform.position = new Vector3(-5f, 1.68f, 0f);
		}
		else if(Player.mana == 250)
		{
			this.transform.position = new Vector3(-5.625f, 1.68f, 0f);
		}
		else if(Player.mana == 200)
		{
			this.transform.position = new Vector3(-6.25f, 1.68f, 0f);
		}
		else if(Player.mana == 150)
		{
			this.transform.position = new Vector3(-6.875f, 1.68f, 0f);
		}
		else if(Player.mana == 100)
		{
			this.transform.position = new Vector3(-7.5f, 1.68f, 0f);
		}
		else if(Player.mana == 50)
		{
			this.transform.position = new Vector3(-8.125f, 1.68f, 0f);
		}
		else if(Player.mana < 50)
		{
			this.transform.position = new Vector3(-8.75f, 1.68f, 0f);
		}
	}

	void UpdateUI ()
	{
		manaText.text = "Mana: " + Player.mana + " / 300";
	}
}

