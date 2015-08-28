using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(RangeDetector))]
public class HealthZone : MonoBehaviour 
{
	RangeDetector detector;
	BaseCharacterClass character;

	public HealthAction action;
	public int value = 10;
	public float speed = 2f;
	float timer = 0f;


	void Awake () 
	{
		detector = gameObject.GetComponent<RangeDetector> ();
		character = detector.target.transform.GetComponent<BaseCharacterClass> ();
	}
	
	void Update () 
	{
		action.Update ();
		if (detector.target.detected)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				timer = speed;
				if      (action.heal)
					character.health.Heal(value);
				else if (action.damage)
					character.health.Damage(value);
			}
		}
	}
}




[System.Serializable]
public class HealthAction
{
	public bool heal = false;
	public bool damage = false;

	public bool Heal {get{ return heal; } set{ heal=value; damage=false; }}
	public bool Damage {get{ return damage; } set{ heal=false; damage=value; }}

	public void Update()
	{
		if (heal && damage)
			damage = false;
	}
}

