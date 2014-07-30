using UnityEngine;
using System.Collections;

public class PowerUpLife : MonoBehaviour {

	public float speed;

	void FixedUpdate () {
		ManagerPowerUp.Instance.movementPowerUps(this.gameObject, speed);
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerLife>().setLife(1);
			Destroy(this.gameObject);
		}
	}
}


