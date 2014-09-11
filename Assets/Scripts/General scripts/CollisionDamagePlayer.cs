using UnityEngine;
using System.Collections;

public class CollisionDamagePlayer : MonoBehaviour {
	
	public float numberColorBlink;
	public float speedColorBlink;

	private int _damage;
	private OrbSize _currentSizeOrb;

	void OnEnable()
	{
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
			ManagerColor.Instance.StartBlink(player, numberColorBlink, speedColorBlink);
		}
	}
}
