using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Nikros : MonoBehaviour {
	[SerializeField]
	Rigidbody rb;
	Animator animador;
	bool correr, voltar, pular;

	[SerializeField]
	LayerMask Ground;

	[SerializeField]
	GameObject HUD;

	[SerializeField]
	BoxCollider colEspada;

	float contador1, contador2, contador3, contadorSofrerAtaque;

	bool sword1, sword2, sword3;

	bool onGround;

	int vel;

	bool canWalk;

	bool pause;

	bool podeApertar = true;

	bool morreu;

	[SerializeField]
	GameObject sword, swordPlaceRunning, swordPlaceAttacking;

	bool sofreuAtaque;

	// Use this for initialization
	void Start () {
		vel = 10;
		//rb = gameObject.GetComponent<Rigidbody> ();
		animador = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (sofreuAtaque == true) 
		{
			contadorSofrerAtaque += Time.deltaTime;
			if(contadorSofrerAtaque >= 1f)
			{
				sofreuAtaque = false;
				contadorSofrerAtaque = 0;
			}
		}

		if (morreu == true) 
		{
			animador.SetBool("Dying", true);
		}

		if(sword1 == false && sword2 == false && sword3 == false)
		{
			colEspada.enabled = false;
			sword.transform.position = swordPlaceRunning.transform.position;
			sword.transform.rotation = swordPlaceRunning.transform.rotation;
		}

		else
		{
			colEspada.enabled = true;
			sword.transform.position = swordPlaceAttacking.transform.position;
			sword.transform.rotation = swordPlaceAttacking.transform.rotation;
		}

		if (sword1 == false && sword2 == false && sword3 == false) 
		{
			canWalk = true;
		} else
			canWalk = false;

		if (sword1 == true) 
		{
			contador1 += Time.deltaTime;

			if(contador1 > animador.GetCurrentAnimatorStateInfo(0).length / 1.3)
			{
				podeApertar = false;
			}

			if (contador1 > animador.GetCurrentAnimatorStateInfo(0).length) 
			{
				sword1 = false;
				contador1 = 0;
				podeApertar = true;
			}
		}

		if (sword2 == true) 
		{
			contador2 += Time.deltaTime;
			if (contador2 > animador.GetCurrentAnimatorStateInfo(0).length) 
			{
				sword2 = false;
				contador2 = 0;
			}
		}

		if (sword3 == true) 
		{
			contador3 += Time.deltaTime;
			if (contador3 > animador.GetCurrentAnimatorStateInfo(0).length) 
			{
				sword3 = false;
				contador3 = 0;
			}
		}

		//onGround = Physics.Linecast (transform.position + Vector3.up, (transform.position - Vector3.up), Ground);

		//raycast
		//RaycastHit rcinfo;
		//rcinfo = Physics.Raycast(transform.position, -Vector3.up, 1f, Ground);

		if (onGround == true) {
			pular = false;
		}

		else 
		{
			pular = true;
		}

		
		/*
		if (rcinfo.collider != null) {
			onGround = true;
		} 

		else 
		{
			onGround = false;
		}

		Debug.Log (onGround);
		*/

		if (morreu == false) {
			if (canWalk == true) {
				rb.velocity = new Vector3 (Input.GetAxis ("Horizontal") * 7, rb.velocity.y, rb.velocity.z);
			}

			if (Input.GetKeyDown (KeyCode.Space) && onGround == true) {
				rb.velocity = new Vector3 (rb.velocity.x, 7, rb.velocity.z);
				pular = true;
			}



			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				correr = true;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 90, transform.eulerAngles.z);
			}

			if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) {
				correr = false;
			}

			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				correr = true;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 270, transform.eulerAngles.z);
			} else if 
			(Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)) {
				correr = false;
			}

			if (onGround == true) {
				if (Input.GetKeyDown (KeyCode.J)) {

					if (sword1 == false && sword2 == false && sword3 == false) {
						animador.SetTrigger ("Sword1");
						sword1 = true;
				
					} else if (sword1 == true) {
						if (podeApertar == true) {
							animador.SetTrigger ("Sword2");
							sword2 = true;
						}
					}

					if (sword2 == true && sword1 == false) {
						animador.SetTrigger ("Sword3");
						sword3 = true;
					}
				}
			}
		}

		animador.SetBool ("run", correr);
		//animador.SetBool ("voltar", voltar);
		animador.SetBool("jump", pular);

		if (morreu == true) 
		{
			
		}
	}

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "Platform") 
		{
			onGround = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag == "Platform")
		{
			onGround = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("EnemyAttack"))
		{
			if(sofreuAtaque == false)
			{
				HUD.GetComponent<HUD>().setVida(-0.2f);
				sofreuAtaque = true;
			}
			//animador.SetTrigger("GettingHit");
		}

		if (col.tag.Equals ("Spike")) 
		{
			HUD.GetComponent<HUD>().setVida(-1);
		}

		if (col.tag.Equals ("LittleSpike")) 
		{
			HUD.GetComponent<HUD>().setVida(-0.2f);
		}
	}

	public void setMorrer(bool valor)
	{
		morreu = valor;
	}

	void GameOver()
	{
		SceneManager.LoadScene ("Menu");
	}
}
