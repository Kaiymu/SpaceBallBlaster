using UnityEngine;
using System.Collections;

public class ManagerInput : MonoBehaviour {

	public static ManagerInput Instance {get; private set;}
	// Keep all the gesture of the game. Really easy if i want to add other key, or a pad for exemple.

	void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;

		DontDestroyOnLoad(gameObject);
	}
	public bool isMovingLeft()
	{
		if(Input.GetKey("q"))
			return true;
		else
			return false;
	}

	public bool isMovingRight()
	{
		if(Input.GetKey("d"))
			return true;
		else
			return false;
	}

	public bool isShooting()
	{
		if(Input.GetKey("space"))
			return true;
		else
			return false;
	}

	public bool isChangingSpellLeft()
	{
		if(Input.GetKeyDown("a"))
			return true;
		else
			return false;
	}

	
	public bool isChangingSpellRight()
	{
		if(Input.GetKeyDown("e"))
			return true;
		else
			return false;
	}
}
