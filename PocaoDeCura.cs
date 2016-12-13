using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PocaoDeCura : MonoBehaviour {
	[SerializeField]
	GameObject[] posItens;

	GameObject hud;

	[SerializeField]
	GameObject pocaoMedia;

	// Use this for initialization
	void Start () {
		hud = GameObject.FindGameObjectWithTag ("HUD");
	}
	
	// Update is called once per frame
	void Update () {

		if (hud == null) 
		{
			hud = GameObject.FindGameObjectWithTag ("HUD");
		}

	}
		
	void OnMouseDown()
	{
		if (gameObject.tag.Equals ("PocaoInventario")) 
		{
			hud.GetComponent<HUD> ().setVida (0.5f);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals ("Player")) {
			Instantiate (pocaoMedia, posItens [0].transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
