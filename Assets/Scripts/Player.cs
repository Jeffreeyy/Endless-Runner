using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private AudioSource audioSource;
    public ParticleSystem particles;
    public float moveSpeed = 7f;
    public static int mana = 300;
	public static int score = 0;
    public static bool isBlinking = false;
	public bool grounded = false;
	public Transform groundedEnd;
	public float jumpForce = 1f;
	private Rigidbody2D rb2d;
	
	private float _blinkCooldown = 1f;
	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource>();
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

		if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && mana > 49 && isBlinking == false)
		{
            particles.Play();
			audioSource.Play();
			isBlinking = true;
			mana -=50;
            gameObject.GetComponent<Renderer>().enabled = false;
            SmallBlinkDelay();
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

    private void SmallBlinkDelay()
    {
        StartCoroutine(SmallBlinkCooldown());
    }

    IEnumerator SmallBlinkCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.right * 3);
        gameObject.GetComponent<Renderer>().enabled = true;
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
		yield return new WaitForSeconds (_blinkCooldown);
		isBlinking = false;
		if(_blinkCooldown > 0f)
		{
			_blinkCooldown -= 0.05f;
		}

	}
}
