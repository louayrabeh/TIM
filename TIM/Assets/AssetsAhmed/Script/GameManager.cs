using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int CrystalNumber=0;
	public Text txt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddCrystal(int CrystalToAdd)
	{
		
		CrystalNumber += CrystalToAdd;
		CrystalNumber++;
	txt.text="Crystal: "+CrystalNumber;
	}
}
