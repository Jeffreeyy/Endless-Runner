using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
    private float _moveSpeed = 0.1f;
    public static int mana = 200;
    
	// Use this for initialization
	void Start () {
		//
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * _moveSpeed);
        }

		if(Input.GetKey (KeyCode.Space))
		{
			transform.Translate(0f,0.5f,0f);
		}
	}
}
