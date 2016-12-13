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
	GameObject HUD, blackScreen, barraDeVida, nome, dialogoCavaleiro, DialogoNikros;

	float contador;
	bool ativarContador;
	bool transicao = true;

	bool playerMorto;
	bool oneTime;

	[SerializeField]
	AudioSource audioCena1, audioCena2, audioCena3, audioGameOver;

	bool batalha;
	bool venceu;
	bool fugiu;

	void Awake()
	{
		fadeout.SetActive(false);
		cam = GetComponent<Camera> ();
		blackScreen.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () {

		playerMorto = player.GetComponent<Nikros> ().GetMorrer ();

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
			if (playerMorto == true) 
			{
				audioCena1.Stop ();
				audioGameOver.Play ();
			}

			audioCena2.Stop ();
			audioCena3.Stop ();
			if (pause == true) {
				audioCena1.volume = 0.2f;
			} else
				audioCena1.volume = 0.8f;

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
			if (playerMorto == true) 
			{
				audioCena2.Stop ();
				audioGameOver.Play ();
			}

			audioCena1.Stop ();
			audioCena3.Stop ();
			if (pause == true) {
				audioCena2.volume = 0.2f;
				audioCena3.volume = 0.2f;
			} else 
			{
				audioCena2.volume = 0.8f;
				audioCena3.volume = 0.8f;
			}

			if (player.transform.position.x <= 473f) {
				if (pause == false) {
					transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 3.5f, pos1.transform.position.z);
				}
			}

			else 
			{
				fadeout.SetActive(true);
				Invoke("TrocarCena2", 3f);
				HUD.GetComponent<HUD> ().setGuardarValor (true);
			}

		}

		else if(cenaAtual == Cena.tres)
		{
			if (batalha == true) 
			{
				if (oneTime == false) 
				{
					barraDeVida.SetActive (true);
					nome.SetActive (true);
					audioCena3.Play ();
					oneTime = true;
				}
			}

			if (batalha == false) 
			{
				if (venceu == true) 
				{
					dialogoCavaleiro.SetActive (true);
					venceu = false;
				}
				if (Input.GetKeyDown (KeyCode.Return)) 
				{
					dialogoCavaleiro.SetActive (false);
				}

				if (fugiu == true) 
				{
					DialogoNikros.SetActive (true);

					if (Input.GetKeyDown (KeyCode.Return)) 
					{
						SceneManager.LoadScene ("Fim");
					}
				}

				barraDeVida.SetActive (false);
				nome.SetActive (false);
				audioCena3.Stop ();
			}

			if (playerMorto == true) 
			{
				audioCena3.Stop ();
				audioGameOver.Play ();
			}

			audioCena1.Stop ();
			audioCena2.Stop ();

			if (pause == true) {
				audioCena3.volume = 0.2f;
			} else 
			{
				audioCena3.volume = 0.8f;
			}

			if (player.transform.position.x <= 473f) {
				if (pause == false) {
					transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 3.5f, pos1.transform.position.z);
				}
			}



		}

		Inventario ();
	}

	void TrocarCena()
	{
			SceneManager.LoadScene("cena2");
	}

	void TrocarCena2()
	{
		SceneManager.LoadScene("cena3");
	}

	void SumirTelaPreta()
	{
		blackScreen.SetActive (false);
	}

	public void SetBatalha(bool valor)
	{
		batalha = valor;
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
	}

	public void SetVenceu(bool valor)
	{
		venceu = valor;
	}

	public void SetFugiu(bool valor)
	{
		fugiu = valor;
	}
}
