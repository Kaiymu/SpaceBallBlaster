using UnityEngine;
using System.Collections;

public class PowerUpTripleShoot : MonoBehaviour {

	private int _ammoTripleShoot;

	public delegate void AmmoTripleShoot();
	public static event AmmoTripleShoot ammoTripleShoot;

	void Start()
	{
		_ammoTripleShoot = ManagerDifficulty.Instance.getAmmoTripleShoot();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerShoot>().setAmmoTripleShoot(_ammoTripleShoot);
			Destroy(this.gameObject);
		}
	}
}
