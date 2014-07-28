using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	// Keep all the gesture of the game. Really easy if i want to add other key, or a pad for exemple.
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
}
