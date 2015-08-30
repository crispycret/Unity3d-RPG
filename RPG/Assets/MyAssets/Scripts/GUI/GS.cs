using UnityEngine;
using System.Collections;


/// <summary>
/// GS.cs
/// GUI Settings
/// An isolated class for storing GUI varaibles
/// </summary>
public class GS : MonoBehaviour {
	
	public static int sw; // Screen width
	public static int sh; // Screen height
	
	
	void Awake () 
	{
		sw = Screen.width;
		sh = Screen.height;

	}
}
