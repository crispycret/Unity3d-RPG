using System;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelSystem
{
	[NonSerialized]
	public BaseCharacterClass character;

	public int level = 0;
	public int exp = 0;

	int expToLevel = 100;
	float level_modifier = 1.4f;


	public string strLevel {get {return level.ToString();}}
	

	public void AddExp(int amount)
	{
		exp += amount;
		if (exp < 0) exp = 0;
		else if (exp >= expToLevel)
		{
			exp -= expToLevel;
			LevelUp();
		}
	}
	
	void LevelUp()
	{
		level += 1;
		AdjustLevelModifier();
		CalculateExpToLevel();

		if (character != null)
			character.CharacterLeveledUp ();
	}

	// Calculate the next required exp to level 
	private void CalculateExpToLevel()
	{expToLevel = (int)(expToLevel * level_modifier);}

	// Determine the value of the level_modifier from the level
	private void AdjustLevelModifier()
	{
		if (9 > level) level_modifier = 1.4f;
		else if (9 < level && level < 20) level_modifier = 1.35f;
		else if (20 < level && level < 30) level_modifier = 1.3f;
		else if (30 < level && level < 40) level_modifier = 1.25f;
	}
}
