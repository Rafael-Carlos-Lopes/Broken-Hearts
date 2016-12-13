using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ParaOMenu : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			SceneManager.LoadScene ("Menu");
		}
	}
		
}
