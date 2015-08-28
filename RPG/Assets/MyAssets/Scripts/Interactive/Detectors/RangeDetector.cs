using UnityEngine;
using System.Collections;
using System;


public class RangeDetector : MonoBehaviour {

	public DetectableTransform target;
	public float range = 5.0F;
	public float distance;

	
	void Update () 
	{
		if (target.transform) {
			Vector3 offset = target.transform.position - transform.position;
			float sqrLen = offset.sqrMagnitude;
			distance = sqrLen / range;
//			if (sqrLen < range * range)
			if (distance < range)
				target.detected = true;
			else 
				target.detected = false;
	
		}
	}
}


[System.Serializable]
public struct DetectableTransform
{
	public bool detected;
	public Transform transform;
		
	DetectableTransform (Transform tr)
	{
		detected = false;
		transform = tr;
	}
}

