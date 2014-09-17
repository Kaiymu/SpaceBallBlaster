using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the power up
** Get the speed from the manager, and give it to the player
************************************************************************************************/

public class PowerUpSetSpeed : MonoBehaviour {

	public float speed;
	
	void FixedUpdate()
	{

		ManagerPowerUp.Instance.movementPowerUps(this.gameObject, speed);
	}
}
