using UnityEngine;
using System.Collections;

public class Espinho : MonoBehaviour {

	float contador;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= 0.25)
		transform.Translate (0, 5 * Time.deltaTime, 0);

		else
		{
			contador += Time.deltaTime;
		}

		if (contador >= 2) 
		{
			Destroy (gameObject);
		}
	}
}
