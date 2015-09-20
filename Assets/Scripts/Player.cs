using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
    public float moveSpeed = 7f;
    public static int mana = 300;
	public static int score = 0;
	public bool grounded = false;
	public Transform groundedEnd;
	public float jumpForce = 1f;
	private Rigidbody2D rb2d;
	private bool _isBlinking = false;
	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Movement ();
		Raycasting ();

		if(this.transform.position.x < -7f || this.transform.position.x > 7f)
		{
			GameOver();
		}
	}

	private void Movement()
	{
		float x = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (x, 0f);
		transform.Translate (movement * moveSpeed * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
		{
			rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && mana > 49 && _isBlinking == false)
		{
			_isBlinking = true;
			mana -=50;
			transform.Translate(Vector2.right * 3);
			BlinkDelay();
		}

		if (grounded == false)
		{
			moveSpeed = 5f;
		}
		else
		{
			moveSpeed = 7f;
		}

	}
	private void GameOver ()
	{
		Time.timeScale = 0f;

	}


	private void Raycasting()
	{
		Debug.DrawLine (this.transform.position, groundedEnd.position, Color.green);

		grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
	}
	private void BlinkDelay()
	{
		StartCoroutine (CooldownTimer ());
	}

	IEnumerator CooldownTimer()
	{
		yield return new WaitForSeconds (1);
		_isBlinking = false;

	}
}
