using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float hp = 0.01f;
	bool morreu;

	Rigidbody rb;
	Animator anim;
	CapsuleCollider cc;
	[SerializeField]
	GameObject essencia;

	Vector3 posEssencia;

	bool dir = false, esq = true;
	bool andando = true;

	[SerializeField]
	GameObject player;

	Vector3 posAlvo;

	bool avistar;
	bool pular;
	bool travar;

	float distancia;

	float delaySofrerAtaque = 0.2f;

	bool sofreuAtaque;

	float contador = 0;

	[SerializeField]
	CapsuleCollider maoEsquerda;

	[SerializeField]
	GameObject barraDeVida;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("MudarDirecao", 4f, 4f);

		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		cc = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp < 0) 
		{
			hp = 0;
		}

		barraDeVida.transform.localScale = new Vector3(hp, barraDeVida.transform.localScale.y, barraDeVida.transform.localScale.z);

		distancia = Vector3.Distance (transform.position, player.transform.position);

		if(morreu == false)
		{
			if(avistar == false)
			{
				if(andando == true)
				{

				if (dir == true) {
						if(avistar == false)
						{
						transform.eulerAngles = new Vector3(transform.eulerAngles.x,90,transform.eulerAngles.z);
						rb.velocity = new Vector3 (4, rb.velocity.y, rb.velocity.z);
						}
				}

				else if (esq == true) {
						if(avistar == false)
						{
						transform.eulerAngles = new Vector3(transform.eulerAngles.x,270,transform.eulerAngles.z);
						rb.velocity = new Vector3 (-4, rb.velocity.y, rb.velocity.z);
						}
				}
				}

				else
				{
					anim.SetBool("Walking", false);
					rb.velocity = new Vector3(0,rb.velocity.y,rb.velocity.z);
				}
			}
		}

		posEssencia = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);

		if(hp <= 0)
		{
			morreu = true;
			anim.SetBool("Dying", true);
			anim.SetBool("Walking", false);
			anim.SetBool("Attacking", false);
			anim.SetBool("Idle", false);
			cc.enabled = false;
			
			Invoke("Morrer", 3f);
		}

		Atacar();

		if (sofreuAtaque == true) 
		{
			delaySofrerAtaque -= Time.deltaTime;

			if(delaySofrerAtaque <= 0)
			{
				sofreuAtaque = false;
			}
		}

	}

	void Morrer()
	{
		Destroy(gameObject);
		GameObject g = (GameObject)Instantiate(essencia,posEssencia,Quaternion.identity);
	}

	void MudarDirecao()
	{
		if(morreu == false)
		{
			if (andando == true) {
				if (esq == false)
				{
					esq = true;
					dir = false;
				} else if (dir == false)
				{
					dir = true;
					esq = false;
				}
			}
		}
	}

	void Atacar()
	{
		if(morreu == false)
			{
			if (travar == true) {
				//posAlvo = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
				//travar = false;
			}

			if(distancia <= 6)
			{
				contador += Time.deltaTime;
				if (contador >= 0.9f) 
				{
					maoEsquerda.enabled = true;
				}

				if (contador >= 1.5f) 
				{
					maoEsquerda.enabled = false;
				}

				if(player.transform.position.x < transform.position.x)
				{
					transform.eulerAngles = new Vector3(transform.eulerAngles.x,270, transform.eulerAngles.z);
				}

				else
				{
					transform.eulerAngles = new Vector3(transform.eulerAngles.x,90, transform.eulerAngles.z);
				}

				if(avistar == false)
				{
				avistar = true;
				anim.SetBool ("Attacking", true);
				anim.SetBool ("Idle", false);
				if (anim.GetBool ("Walking") == true) {
					anim.SetBool ("Walking", false);
				}
				andando = false;
				//posAlvo = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
				anim.SetBool ("Attacking", true);
				//transform.position = Vector3.MoveTowards(transform.position, posAlvo, 0.03f);
				Invoke ("ResetarAtaque", 2f);
				}
			}


			//if(transform.position == posAlvo)
			//{
			//	anim.SetBool("Idle", true);
			//	anim.SetBool("Attacking", false);
			//	anim.SetBool("Walking", false);
			//}
		}
	}

		


	void ResetarAtaque()
	{
		if(morreu == false)
			{
			contador = 0;
			avistar = false;
			andando = true;
			anim.SetBool("Walking", true);
			anim.SetBool("Attacking", false);
			anim.SetBool("Idle", false);
			maoEsquerda.enabled = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Sword"))
		{
			if(sofreuAtaque == false)
			{
			hp -= 0.002f;
			sofreuAtaque = true;
			}
		}
	}

	public void setAvistar(bool valor)
	{
		avistar = valor;
	}

	public void setPular(bool valor)
	{
		pular = valor;
	}

	public void setTravar(bool valor)
	{
		travar = valor;
	}
}