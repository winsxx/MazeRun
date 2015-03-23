﻿using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
	public Texture2D texture;
	static LoadingScreen instance;
	
	void Awake()
	{
		if (instance)
		{
			Destroy(gameObject);
			hide();
			return;
		}
		instance = this;    
		gameObject.AddComponent<GUITexture>().enabled = false;
		guiTexture.texture = texture;
		transform.position = new Vector3(0.5f, 0.5f, 1f);
		DontDestroyOnLoad(this); 
	}

	void Update()
	{
		if(!Application.isLoadingLevel)
			hide();
	}

	public static void show()
	{
		if (!InstanceExists()) 
		{
			return;
		}
		instance.guiTexture.enabled = true;
	}
	
	public static void hide()
	{
		if (!InstanceExists()) 
		{
			return;
		}
		instance.guiTexture.enabled = false;
	}
	
	static bool InstanceExists()
	{
		if (!instance)
		{
			return false;
		}
		return true;
		
	}
	
}