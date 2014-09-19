using UnityEngine;
using System.Collections;

/************************************************************************************************
* Only on the darkness orb
**  Make the cloud move up and down to make a wind effect
************************************************************************************************/

public class OrbCollisionDamagePlayer : MonoBehaviour {
	
	public float numberColorBlink;
	public float speedColorBlink;

	private int _damage;
	private OrbSize _currentSizeOrb;
	private ManagerColor _managerColor;
	private ManagerDifficulty _managerDifficulty;

	void OnEnable()
	{
		_managerColor = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerColor>();
		_managerDifficulty = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerDifficulty>();
		_currentSizeOrb = this.GetComponent<OrbSize>();

		if(_currentSizeOrb.sizeOrb == OrbSize.Size.normalSize)
			_damage = _managerDifficulty.getDamageNormalOrb();

		if(_currentSizeOrb.sizeOrb == OrbSize.Size.midSize)
			_damage = _managerDifficulty.getDamageMidOrb();

		if(_currentSizeOrb.sizeOrb == OrbSize.Size.smallSize)
			_damage = _managerDifficulty.getDamageSmallOrb();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerLife>().setLife(_damage);
			GameObject player = col.transform.gameObject;
			_managerColor.StartBlink(player, numberColorBlink, speedColorBlink);
		}
	}
}
