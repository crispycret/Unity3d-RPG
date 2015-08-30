using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BaseCharacterClass))]
public class PlayerGUI : MonoBehaviour 
{
	BaseCharacterClass player;

	public bool useImages = true;

	public Texture2D imgLevel;
	public Texture2D imgHealth;
	public Texture2D imgHealthBar;

	public GUISkin skin;

	Rect rlvl;
	Rect rhealth;
	Rect rmaxhealth;

	float health_bar_width;
	float health_bar_height;
	float max_health_bar_width;

	Color old_text_color;
	Color old_background_color;

	private static Texture2D _staticRectTexture;


	void Awake()
	{
		player = gameObject.GetComponent<BaseCharacterClass> ();
	}


	void Start()
	{

		max_health_bar_width = GS.sw / 2.7f;
		health_bar_height = GS.sh / 25f;
		health_bar_width = max_health_bar_width;

		rlvl = new Rect (5, 5, 92, 64);
		rhealth = new Rect (10, 10, health_bar_width, health_bar_height);
		rmaxhealth = new Rect (10, 10, max_health_bar_width, health_bar_height);

		rhealth.x += rlvl.x + rlvl.width;
		rmaxhealth.x += rlvl.x + rlvl.width;
	}

	
	void OnGUI()
	{
		GUI.skin = skin;
		if (useImages)
		{
			DrawLevelWithImage();
			DrawHealthBarWithImage();
		}
		else
		{
			InitializeGUIBoxColor ();
			old_background_color = GUI.backgroundColor;
			GUI.backgroundColor = Color.black;

			DrawLevelBoxWithGUIBox ();
			DrawHealthBarWithGUIBox ();
		}
		
	}



	void InitializeGUIBoxColor()
	{
		if (_staticRectTexture == null)
		{
			_staticRectTexture = new Texture2D (1, 1);
		}
		_staticRectTexture.SetPixel (0, 0, Color.white);
		_staticRectTexture.Apply ();
		
		// Updates contentColor and bacgroundColor
		GUI.skin.box.normal.background = _staticRectTexture;
		GUI.skin.box.normal.textColor = Color.white;
		
		// Or instead
		
		old_text_color = GUI.contentColor;
		old_background_color = GUI.backgroundColor;
	}

	void CalculateHealthWidth()
	{
		health_bar_width = max_health_bar_width * player.health.Percent;
		rhealth.width = health_bar_width;
	}



	void DrawLevelWithImage()
	{
		GUI.backgroundColor = Color.clear;
		GUI.DrawTexture (rlvl, imgLevel, ScaleMode.StretchToFill);
		GUI.Box (rlvl, player.level.strLevel);
	}
	void DrawHealthBarWithImage()
	{

		GUI.DrawTexture (rmaxhealth, imgHealthBar);
		CalculateHealthWidth ();

		if (health_bar_width != 0)
			GUI.DrawTexture (rhealth, imgHealth);

		GUI.Box (rmaxhealth, 
	        player.health.strHealth + " / " +
			player.health.strMaxHealth);
	}






	void DrawLevelBoxWithGUIBox()
	{
		
		GUI.contentColor = Color.yellow;
		GUI.Box (rlvl, player.level.strLevel);
	}
	void DrawHealthBarWithGUIBox()
	{
		GUI.Box (rmaxhealth, "");
		CalculateHealthWidth ();
		if (health_bar_width != 0) {
			GUI.backgroundColor = Color.red;
			GUI.Box (rhealth, "");
		}
	}
}
