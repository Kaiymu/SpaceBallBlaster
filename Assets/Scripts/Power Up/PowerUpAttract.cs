using UnityEngine;
using System.Collections;

public class PowerUpAttract : MonoBehaviour {

	private int _ammoAttractShoot;

	void Start()
	{
		_ammoAttractShoot = ManagerDifficulty.Instance.getAmmoAttractShoot();
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerShoot>().setAmmoAttractShoot(_ammoAttractShoot);
			Destroy(this.gameObject);
		}
	}
}