using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RangeDetector))]
public class HealthAction : MonoBehaviour 
{
	public HealthActions actions;
	public RangeDetector detector;
	public BaseCharacterClass target;

	public int range = 2;
	public int value = 5;
	public float speed = 5;
	float timer = 0;

	void Awake ()
	{
		actions = new HealthActions ();
		detector = gameObject.GetComponent<RangeDetector> ();
	}

	void Start ()
	{
		detector.target.transform = target.transform;
		detector.range = range;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (detector.target.detected)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				timer = speed;
				DoAction ();
			}
		}
	
	}

	void DoAction()
	{
		// The damage value should be calculate
		// from a high level script like EnemyAttack
		if (actions.Heal)
			target.health.Heal (value);
		else if (actions.Damage)
			target.health.Damage (value);
	}
}






[System.Serializable]
public struct HealthActions
{
	[SerializeField]
	private bool _heal;
	[SerializeField]
	private bool _damage;


	void HealthAction()
	{ 
		_heal = false; _damage = false; 
	}
	void HealthAction(bool heal, bool damage)
	{ 
		_heal = heal; _damage = damage; 
	}


	public bool Heal 
	{
		get{return _heal;} 
		set{ 
			_heal = value;
			if (_heal) _damage = false;
		}
	}

	public bool Damage {
		get{ return _damage; }
		set{ 
			_damage = value; 
			if (_damage) _heal = false;
		}
	}
	
}



