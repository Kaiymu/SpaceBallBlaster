using UnityEngine;
using System.Collections;

public class PowerUpTripleShoot : MonoBehaviour {

	public float speed;

	void FixedUpdate()
	{
		ManagerPowerUp.Instance.movementPowerUps(this.gameObject, speed);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerShoot>().shootType = PlayerShoot.ShootType.tripleShoot;
			Destroy(this.gameObject);
		}
	}
}
