using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickUp : MonoBehaviour {
	public int value;
	public GameObject PickUpEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			FindObjectOfType<GameManager>().AddCrystal(value);
			Instantiate (PickUpEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}
}
