using UnityEngine;
using System.Collections;

public class PowerUpLife : MonoBehaviour {

	private int _bonusLife;

	void Start()
	{
		_bonusLife = ManagerDifficulty.Instance.getAmmoLife();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{	
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerLife>().setLife(_bonusLife);
			Destroy(this.gameObject);
		}
	}
}


