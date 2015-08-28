using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RangeDetector))]
public class ExpBooth : MonoBehaviour 
{
	RangeDetector detector;
	BaseCharacterClass character;

	public int value = 10; 
	public float speed = 1f;  
	float timer = 0f;



	void Awake () 
	{
		detector = gameObject.GetComponent<RangeDetector> ();
		detector.range = 2;

		character = detector.target.transform.GetComponent<BaseCharacterClass>();
	}
	
	void Update () 
	{
		if (detector.target.detected)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				timer = speed;
				character.level.AddExp(value);
			}
		}
	
	}
}
