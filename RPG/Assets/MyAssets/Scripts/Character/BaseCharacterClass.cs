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
	

	void OnGUI()
	{
		Rect rlvl = new Rect (5, 5, 35, 50);
		GUI.Box (rlvl, level.level.ToString());

		float hbw = GS.max_hb_w * health.Percent; // Health Bar Width
		Rect rhb = new Rect (10, 10, hbw, GS.hb_h);
		rhb.x += rlvl.x + rlvl.width;
		GUI.Box (rhb, "Health: " + health.strHealth);
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
