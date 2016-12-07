using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuCreditos : MonoBehaviour {

	SpriteRenderer sr;
	
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
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
		SceneManager.LoadScene("Creditos");
	}
}
