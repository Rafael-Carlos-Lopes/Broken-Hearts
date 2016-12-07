using UnityEngine;
using System.Collections;

public class Essencia : MonoBehaviour {
	GameObject HUD;

	// Use this for initialization
	void Start () {
		transform.eulerAngles = new Vector3(270,0,0);
		HUD = GameObject.FindGameObjectWithTag ("HUD");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals ("Player")) 
		{
			HUD.GetComponent<HUD>().setNumEssencias(10);
			Destroy(gameObject);
		}
	}
}
