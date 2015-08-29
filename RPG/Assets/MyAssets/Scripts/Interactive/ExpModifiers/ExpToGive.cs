using UnityEngine;
using System.Collections;

public class ExpToGive : MonoBehaviour 
{
	public int value = 0;
	
	
	// use the difference in the level, any buffs, states, or other
	// parameters to calculate the exp to give the killer based on
	// the variable value.
	public void KillExpToGive(BaseCharacterClass killed, BaseCharacterClass killer)
	{
		float percent = (float)killed.level.level / killer.level.level;
		int exp = (int)(value * percent);
		killer.level.AddExp(exp);
	}
	
	// Add any amount of exp
	public void GiveExpToCharacter(int exp, BaseCharacterClass character)
	{
		character.level.AddExp (exp);
	}
}
