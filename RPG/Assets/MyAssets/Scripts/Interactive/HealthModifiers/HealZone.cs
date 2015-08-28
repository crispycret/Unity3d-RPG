using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RangeDetector))]
public class HealZone : MonoBehaviour {

	RangeDetector detector;
	BaseCharacterClass character;

	public int value = 10;
	public float speed = 2;
	float timer = 0f;

	void Awake () 
	{
		detector = gameObject.GetComponent<RangeDetector> ();
		character = detector.target.transform.GetComponent<BaseCharacterClass> ();
	}
	
	void Update () 
	{
		if (detector.target.detected)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				timer = speed;
				character.health.Heal(value);
			}
		}
	
	}
}
