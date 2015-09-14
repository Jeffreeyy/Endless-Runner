using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float _blinkDelay = 2;
    private float _moveSpeed = 0.1f;
    //private Collider2D _wallCollider;

    //public Transform wallPrefab;
    
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        //_wallCollider = wallPrefab.GetComponent<Collider2D>();
=======
>>>>>>> origin/master
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        

        /*if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _wallCollider.enabled = false;
            Debug.Log(_wallCollider.enabled);
            Debug.Log(_wallCollider);
            PlayerBlink();
        }
        */
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * _moveSpeed);
        }
        
=======
		transform.Translate(5f * Time.deltaTime, 0f, 0f);

		if(Input.GetKey (KeyCode.Space))
		{
			transform.Translate(0f,0.5f,0f);
		}
>>>>>>> origin/master

	}

    /*void PlayerBlink()
    {
        StartCoroutine(BlinkDelay());
    }

    IEnumerator BlinkDelay() 
    {
        yield return new WaitForSeconds(_blinkDelay);
        _wallCollider.enabled = true;
        Debug.Log(_wallCollider.enabled);
        
    }
     */

}
