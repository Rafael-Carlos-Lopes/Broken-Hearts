using UnityEngine;
using System.Collections;

public class CavaleiroNegro : MonoBehaviour {

	float hp = 1;
	bool morreu;

	Rigidbody rb;
	Animator anim;

	[SerializeField]
	GameObject player;

	float delaySofrerAtaque = 0.3f;

	bool sofreuAtaque;

	float contador = 0;

	[SerializeField]
	GameObject barraDeVida, nome;

	int ataque;
	float contadorAtaque;

	[SerializeField]
	GameObject espinho, camera;

	[SerializeField]
	GameObject[] posEspinhos;

	float distancia;

	bool batalha;
	bool fugindo;
	bool repetir;

	[SerializeField]
	CapsuleCollider cc;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp < 0) 
		{
			hp = 0;
		}

		distancia = Vector3.Distance (transform.position, player.transform.position);

		if (distancia < 6) 
		{
			camera.GetComponent<CameraBehaviour> ().SetBatalha (true);
			batalha = true;
		}

		barraDeVida.transform.localScale = new Vector3(hp, barraDeVida.transform.localScale.y, barraDeVida.transform.localScale.z);

		if (morreu == false) {
			if (batalha == true) {
				contadorAtaque += Time.deltaTime;

				if (contadorAtaque >= 4) {
					ataque = Random.Range (1, 3);
					if (ataque == 1) {
						anim.SetTrigger ("Ataque1");
					}

					if (ataque == 2) {
						anim.SetTrigger ("Ataque2");
						Instantiate (espinho, posEspinhos [0].transform.position, Quaternion.identity);
						Instantiate (espinho, posEspinhos [1].transform.position, Quaternion.identity);
						Instantiate (espinho, posEspinhos [2].transform.position, Quaternion.identity);
					}

					contadorAtaque = 0;
					ataque = 0;
				}
			}
		}

		if(hp <= 0)
		{
			morreu = true;
			player.GetComponent<Nikros> ().SetCanWalk (false);
			player.GetComponent<Nikros> ().SetDialogo (true);
			camera.GetComponent<CameraBehaviour> ().SetBatalha (false);
			anim.SetBool ("Vencido", true);
			if (repetir == false) {
				camera.GetComponent<CameraBehaviour> ().SetVenceu (true);
				repetir = true;
			}

			if (Input.GetKeyDown (KeyCode.Return))
			{
				fugindo = true;
			}

			if (fugindo == true) 
			{
				rb.useGravity = false;
				cc.enabled = false;
				transform.Translate (0, -1 * Time.deltaTime, 0);
			}
		}

		if (transform.position.y <= -3.5f)
		{
			camera.GetComponent<CameraBehaviour> ().SetFugiu (true);
		}

		if (sofreuAtaque == true) 
		{
			delaySofrerAtaque -= Time.deltaTime;

			if(delaySofrerAtaque <= 0)
			{
				sofreuAtaque = false;
				delaySofrerAtaque = 0.3f;
			}
		}

	}

	void Morrer()
	{
		Destroy(gameObject);
	}
		
	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Sword"))
		{
			if(sofreuAtaque == false)
			{
			hp -= 0.05f;
			sofreuAtaque = true;
			}
		}
	}
}