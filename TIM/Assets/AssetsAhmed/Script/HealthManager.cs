using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public int maxHealth;
	public int Health;
	public PlayerController thePlayer;
	void Start () {
		Health = maxHealth;
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HurtPlayer(int damage,Vector3 direction)
	{
		Health -= damage;
		thePlayer.knockback(direction);
	}
	public void HealPlayer(int Healing)
	{
		Health += Healing;
		if (Health > maxHealth) 
		{
			Health = maxHealth;
		}
	}
}
