using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	[SerializeField]
	GameObject tutorialMovimento, tutorialAtaque, tutorialPulo, tutorialInventario, player;

	float contador;

	bool areaTut1, areaTut2, areaTut3, areaTut4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (tutorialMovimento != null) {
			if (player.transform.position.x > tutorialMovimento.transform.position.x) {
				areaTut1 = true;
				tutorialMovimento.SetActive (true);
			}
		}

		if (tutorialAtaque != null) {
			if (player.transform.position.x > tutorialAtaque.transform.position.x) {
				areaTut2 = true;
				tutorialAtaque.SetActive (true);
			}
		}

		if (tutorialPulo != null) {
			if (player.transform.position.x > tutorialPulo.transform.position.x) {
				areaTut3 = true;
				tutorialPulo.SetActive (true);
			}
		}

		if (tutorialInventario != null) {
			if (player.transform.position.x > tutorialInventario.transform.position.x) {
				areaTut4 = true;
				tutorialInventario.SetActive (true);
			}
		}

		if (areaTut1 == true) 
		{
			contador += Time.deltaTime;
			if(contador > 3)
			{
				contador = 0;
				areaTut1 = false;
				Destroy(tutorialMovimento);
			}
		}

		if (areaTut2 == true) 
		{
			contador += Time.deltaTime;
			if(contador > 3)
			{
				contador = 0;
				areaTut2 = false;
				Destroy(tutorialAtaque);
			}
		}

		if (areaTut3 == true) 
		{
			contador += Time.deltaTime;
			if(contador > 3)
			{
				contador = 0;
				areaTut3 = false;
				Destroy(tutorialPulo);
			}
		}

		if (areaTut4 == true) 
		{
			contador += Time.deltaTime;
			if(contador > 3)
			{
				contador = 0;
				areaTut4 = false;
				Destroy(tutorialInventario);
			}
		}

	}
}
