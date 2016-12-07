using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraBehaviour : MonoBehaviour {

	[SerializeField]
	GameObject fadeout;

	enum Cena{um, dois, tres};
	[SerializeField]
	Cena cenaAtual;

	[SerializeField]
	GameObject player;

	bool pause;

	[SerializeField]
	GameObject pos1, pos2;

	Camera cam;

	[SerializeField]
	GameObject HUD, blackScreen;

	float contador;
	bool ativarContador;
	bool transicao = true;

	void Awake()
	{
		fadeout.SetActive(false);
		cam = GetComponent<Camera> ();
		blackScreen.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () {

		Debug.Log (contador);

		//Inventario
		if (pause == true) {
			if(transicao == true)
			{
			ativarContador = true;
			if(ativarContador == true)
			{	
				blackScreen.SetActive (true);
				contador += Time.deltaTime;
			}
			if (contador >= 0.2f) {
				blackScreen.SetActive (false);
				Time.timeScale = 0;
				transform.position = pos2.transform.position;
				cam.orthographic = true;
				HUD.SetActive (false);
				ativarContador = false;
				contador = 0;
				transicao = false;
			}
			}
		} 

		if (pause == false) 
		{
			if(transicao == true)
			{
			ativarContador = true;
			if(ativarContador == true)
			{	
				blackScreen.SetActive (true);
				contador += Time.deltaTime;
			}
			if (contador >= 0.2f) 
			{
				blackScreen.SetActive(false);
				ativarContador = false;
				contador = 0;
				transicao = false;
			}
			Time.timeScale = 1;
			cam.orthographic = false;
			HUD.SetActive (true);
			}
		}

		if(cenaAtual == Cena.um)
		{
		if (player.transform.position.x <= 204.5f) {
				if(pause == false)
				{
				transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 3.5f, pos1.transform.position.z);
				}
		}

		else 
			{
				fadeout.SetActive(true);
				Invoke("TrocarCena", 3f);
				HUD.GetComponent<HUD> ().setGuardarValor (true);
			}
		}

		else if(cenaAtual == Cena.dois)
		{
			if(pause == false)
			{
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 3.5f, pos1.transform.position.z);
			}
		}

		Inventario ();
	}

	void TrocarCena()
	{
			SceneManager.LoadScene("cena2");
	}

	void SumirTelaPreta()
	{
		blackScreen.SetActive (false);
	}

	void Inventario()
	{
		if (Input.GetKeyDown (KeyCode.I)) {
			if (pause == true) {
				pause = false;
				transicao = true;
			}

			else if (pause == false) 
			{
				pause = true;
				transicao = true;
			}
		}
		/*
		if (pause == true) {
			contador += Time.deltaTime;
			if (contador >= 0.5f) 
			{
				blackScreen.SetActive (false);
			}
			if (contador < 0.5f) {
				blackScreen.SetActive (true);
			}
			Time.timeScale = 0;
			transform.position = pos2.transform.position;
			cam.orthographic = true;
			HUD.SetActive (false);
		} 

		else if(pause == false) {
			Time.timeScale = 1;
			cam.orthographic = false;
			HUD.SetActive (true);
		}
		*/
	}
}
