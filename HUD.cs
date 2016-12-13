using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	[SerializeField]
	TextMesh numDeEssencias;

	[SerializeField]
	Transform barraDeVida;

	[SerializeField]
	SpriteRenderer coracao;

	[SerializeField]
	GameObject player;

	float vida = 1;
	int numDeEssenciasInt;

	bool guardarValor;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetFloat ("Vida", 1); //nao esquecer de comentar depois
		//	PlayerPrefs.SetInt ("NumDeEssencias", 0);
		vida = PlayerPrefs.GetFloat ("Vida");
		numDeEssenciasInt = PlayerPrefs.GetInt("NumDeEssencias");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (guardarValor == true) 
		{
			PlayerPrefs.SetFloat ("Vida", vida);
			PlayerPrefs.SetInt ("NumDeEssencias", numDeEssenciasInt);
		}

		numDeEssencias.text = "= " + numDeEssenciasInt;

		if(Input.GetKeyDown(KeyCode.P))
		{
			numDeEssenciasInt += 10;
		}

		barraDeVida.localScale = new Vector3 (vida, barraDeVida.localScale.y, barraDeVida.localScale.z);

		if (vida > 1) 
		{
			vida = 1;
		}

		if (barraDeVida.localScale.x < 0) {
			barraDeVida.localScale = new Vector3(0,barraDeVida.localScale.y, barraDeVida.localScale.z);
		}

		if (barraDeVida.localScale.x > 1) {
			barraDeVida.localScale = new Vector3(1,barraDeVida.localScale.y, barraDeVida.localScale.z);
		}

		if(barraDeVida.localScale.x <= 0)
			player.GetComponent<Nikros>().setMorrer(true);
		
		if(Input.GetKeyDown(KeyCode.O))
		{
			vida -= 0.5f;
		}

		if (vida == 1) 
		{
			coracao.color = Color.white;
		}

		else if (vida <= 0.5f) 
		{
			coracao.color = Color.gray;
		}

		else if (vida == 0) 
		{
			coracao.color = Color.black;
		}
	}

	public void setVida(float valor)
	{
		vida += valor;
	}

	public void setNumEssencias(int valor)
	{
		numDeEssenciasInt += valor;
	}

	public void setGuardarValor(bool valor)
	{
		guardarValor = valor;
	}
}
