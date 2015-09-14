using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Example());
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(5);
		AutoFade.LoadLevel("menu",2,1,Color.white);
	}

	// Update is called once per frame
#if UNITY_EDITOR
	void Update () {
		if (Input.GetMouseButton(0))
		{
			AutoFade.LoadLevel("menu",2,1, Color.white);
		}
	}
#endif
}
