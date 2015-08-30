using UnityEngine;
using System.Collections;

public class BaseCharacterClass : MonoBehaviour 
{
	public LevelSystem level;
	public HealthSystem health;

	void Awake ()
	{
		level = new LevelSystem ();
		level.character = this;
		health = new HealthSystem ();
	}

	void Start () 
	{
		health.FullRestore ();
	}

	void Update ()
	{
		UpdateEditorValues ();
	}
	


	
	// Called by LevelSystem, when we LevelUp 
	public void CharacterLeveledUp()
	{
		health.LevelUp ();
	}


	// Call the methods required for updating the values 
	// in the UnityEditor. Remove when building the game
	void UpdateEditorValues()
	{
		level.AddExp (0);
		health.Heal (0);
		health.Damage (0);
	}
	

}
