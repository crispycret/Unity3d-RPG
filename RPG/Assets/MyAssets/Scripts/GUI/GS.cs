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
	
	public static int hb_h; // Health bar height
	public static int max_hb_w; // Max health bar width
	
	void Awake () 
	{
		sw = Screen.width;
		sh = Screen.height;

		hb_h = (int)(sh / 25f);
		max_hb_w = (int)(sw / 2.7f);
	}
}
