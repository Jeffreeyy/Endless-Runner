using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {	
		//When player picks up mana and does not have 300 mana
        if (col.gameObject.tag == "Player" && Player.mana < 299)
        {
            Player.mana += 50;
            Destroy(this.gameObject);
        }
		else
		{
			Destroy(this.gameObject);
		}
    }
    
}
