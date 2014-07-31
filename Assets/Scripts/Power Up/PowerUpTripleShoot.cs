using UnityEngine;
using System.Collections;

public class PowerUpTripleShoot : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerShoot>().ammoTripleShoot = 5;
			Destroy(this.gameObject);
		}
	}
}
