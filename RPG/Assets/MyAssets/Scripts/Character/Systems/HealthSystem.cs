using System;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class HealthSystem
{
	public int health = 0;
	public int max_health = 50;
	float level_modifier = 1.3f;

	// return percentage of health left
	public float Percent {get {return (float)health / max_health;}}
	// return health as a string
	public string strHealth {get {return health.ToString();}}


	// Max out health
	public void FullRestore() 
	{ health = max_health; }



	// Add to health
	public void Heal(int value)
	{
		health += value;
		if (health > max_health) FullRestore();
	}

	// Subtract from health
	public void Damage(int value)
	{
		health -= value;
		if (health <= 0) health = 0;
	}
	


	// Should be called by BaseCharacterClass
	public void LevelUp()
	{
		max_health = (int)(max_health * level_modifier);
		FullRestore ();
	}

}
