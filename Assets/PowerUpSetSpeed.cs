using UnityEngine;
using System.Collections;

public class PowerUpSetSpeed : MonoBehaviour {

	public float speed;
	
	void FixedUpdate()
	{
		ManagerPowerUp.Instance.movementPowerUps(this.gameObject, speed);
	}
}
