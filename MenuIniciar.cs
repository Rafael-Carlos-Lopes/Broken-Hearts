using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuIniciar : MonoBehaviour {

	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver()
	{
		sr.color = Color.cyan;
	}

	void OnMouseExit()
	{
		sr.color = Color.white;
	}

	void OnMouseDown()
	{
		SceneManager.LoadScene("cena1");
	}
}
