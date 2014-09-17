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

	void OnEnable()
	{
		_managerColor = ManagerColor.Instance;
		_currentSizeOrb = this.GetComponent<OrbSize>();

		if(_currentSizeOrb.sizeOrb == OrbSize.Size.normalSize)
			_damage = ManagerDifficulty.Instance.getDamageNormalOrb();

		if(_currentSizeOrb.sizeOrb == OrbSize.Size.midSize)
			_damage = ManagerDifficulty.Instance.getDamageMidOrb();

		if(_currentSizeOrb.sizeOrb == OrbSize.Size.smallSize)
			_damage = ManagerDifficulty.Instance.getDamageSmallOrb();
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
