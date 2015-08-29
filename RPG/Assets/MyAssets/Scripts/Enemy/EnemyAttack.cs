using UnityEngine;
using System.Collections;


[RequireComponent(typeof(HealthAction))]
public class EnemyAttack : MonoBehaviour 
{
	public bool can_attack = true;
	public HealthAction health_action;
	public BaseCharacterClass target;

	public int damage = 10;
	public int attack_range = 5;
	public int attack_speed = 2;



	void SetHealthActionVariables()
	{
		health_action.range = attack_range;
		health_action.target = target;
		health_action.value = damage;
		health_action.speed = attack_speed;
	}


	void Awake ()
	{
		if (!can_attack)
			return;
		health_action = gameObject.GetComponent<HealthAction> ();
		SetHealthActionVariables ();
	}

	void Start()
	{
		health_action.actions.Damage = true;
	}



}
