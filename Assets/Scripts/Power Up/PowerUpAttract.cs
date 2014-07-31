using UnityEngine;
using System.Collections;

public class PowerUpAttract : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerShoot>().ammoAttractShoot = 5;
			Destroy(this.gameObject);
		}
	}
}