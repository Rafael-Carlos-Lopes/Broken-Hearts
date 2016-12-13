using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Introducao : MonoBehaviour {

	[SerializeField]
	TextMesh TextoIntroducao, TextoIntroducao2, TextoIntroducao3;

	float contador = 0;
	int contadorTexto = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		contador += Time.deltaTime;

		if (contador > 7) 
		{
			contadorTexto++;
			contador = 0;
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			SceneManager.LoadScene ("cena1");
		}

		if (contadorTexto == 0) 
		{
			TextoIntroducao.text = "EM UMA TERRA DISTANTE HAVIA UM ";
			TextoIntroducao2.text = "ELFO NEGRO CHAMADO NIKROS";
		}

		if (contadorTexto == 1) 
		{
			TextoIntroducao.text = "ELE ERA COMANDANTE DE UM ";
			TextoIntroducao2.text = "EXÉRCITO LIDERADO POR LOLTH,";
			TextoIntroducao3.text = "A RAINHA DOS ELFOS NEGROS";
		}

		if (contadorTexto == 2) 
		{
			TextoIntroducao.text = "EM UM DE SEUS ATOS, NIKROS";
			TextoIntroducao2.text = "SE ENCONTROU COM UMA HUMANA";
			TextoIntroducao3.text = "CHAMADA URBI";
		}

		if (contadorTexto == 3) 
		{
			TextoIntroducao.text = "OS DOIS COMEÇARAM UM ROMANCE";
			TextoIntroducao2.text = "PROIBIDO E NIKROS DECIDIU";
			TextoIntroducao3.text = "SE DESLIGAR DE SEU EXÉRCITO";
		}

		if (contadorTexto == 4) 
		{
			TextoIntroducao.text = "LOLTH, ENFURECIDA COM ISSO";
			TextoIntroducao2.text = "ENVIOU UM MERCENÁRIO QUE TINHA";
			TextoIntroducao3.text = "A MISSÃO DE SEQUESTRAR URBI";
		}

		if (contadorTexto == 5) 
		{
			TextoIntroducao.text = "NIKROS ENTÃO COMEÇA A PERSEGUIR";
			TextoIntroducao2.text = "O MERCENÁRIO PARA SALVAR URBI.";
			TextoIntroducao3.text = "";
		}

		if (contadorTexto == 6) 
		{
			SceneManager.LoadScene("cena1");
		}
	}
}
