using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour {
	[SerializeField]
	GameObject[] posItens;

	[SerializeField]
	GameObject pocaoPequena, pocaoMedia;

	// 0 = false 1 = true
	[SerializeField]
	int[] espacoOcupado;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.T)) 
		Instantiate(pocaoMedia, posItens[0].transform.position, Quaternion.identity);

	}
}
