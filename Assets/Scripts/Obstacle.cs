using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    private Collider2D _wallCollider;
	// Use this for initialization
	void Start () {
        _wallCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	     if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _wallCollider.enabled = false;
            obstacleColliderRemove();
	    }
    }

    void obstacleColliderRemove()
    {
        StartCoroutine(RemoveDelay());
    }

    IEnumerator RemoveDelay()
    {
        yield return new WaitForSeconds(2);
        _wallCollider.enabled = true;
    }
}
