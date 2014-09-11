﻿using UnityEngine;
using System.Collections;

public class ManagerInput : MonoBehaviour {

	public static ManagerInput Instance {get; private set;}
	// Keep all the gesture of the game. Really easy if i want to add other key, or a pad for exemple.

	private bool touchingLeft, touchingRight, fire, changeArrowRight, changeArrowLeft, pausingGame, quittingGame;

	void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;

		DontDestroyOnLoad(gameObject);
	}

	void isTouchingLeft()
	{
		touchingLeft = true;
	}
	
	void isRealeasingLeft()
	{
		touchingLeft = false;
	}

	void isTouchingRight()
	{
		touchingRight = true;
	}
	
	void isRealeasingRight()
	{
		touchingRight = false;
	}

	void isFiring()
	{
		fire = true;
	}
	
	void isRealeasingFire()
	{
		fire = false;
	}

	void isChangingArrowLeft()
	{
		changeArrowLeft = true;
	}
	
	void isChangingArrowRight()
	{
		changeArrowRight = true;
	}

	void isPausingGame()
	{
		pausingGame = true;
	}

	void isQuittingGame()
	{
		quittingGame = true;
	}
	
	public bool isMovingLeft()
	{
		if(Input.GetKey("q") || touchingLeft)
			return true;
		else
			return false;

	}

	public bool isMovingRight()
	{
		if(Input.GetKey("d") || touchingRight)
			return true;
		else
			return false;
	}

	public bool isShooting()
	{
		if(Input.GetKey("space") || fire)
			return true;
		else
			return false;
	}

	public bool isChangingAmmoLeft()
	{
		if(Input.GetKeyDown("a") || changeArrowLeft)
		{
			changeArrowLeft = false;
			return true;
		}
		else
			return false;
	}

	
	public bool isChangingAmmoRight()
	{
		if(Input.GetKeyDown("e") || changeArrowRight)
		{
			changeArrowRight = false;
			return true;
		}
		else
			return false;

	}

	public bool isPausing()
	{
		if(Input.GetKeyDown("p") || pausingGame)
		{	pausingGame = false;
			return true;
		}
		else
			return false;
	}

	public bool isQuitting()
	{
		if(Input.GetKeyDown("t") || quittingGame)
		{	quittingGame = false;
			return true;
		}
		else
			return false;
	}
}
