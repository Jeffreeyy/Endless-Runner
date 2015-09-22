using UnityEngine;
using System.Collections;

public class IntroMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale += new Vector3 (0.0005f, 0.0005f, 0);
	}
}
