using UnityEngine;
using System.Collections;

public class SetPositionBorderArrowType : MonoBehaviour {
	
	private GameObject _UIBorder;

	private PlayerShoot _arrowType;
	private int _posArrayArrow;

	private GiveAllObjectsToManagers _giveAllObjectsToManagers;

	private bool _isInMenu;

	void OnEnable()
	{
		PlayerShoot.isChangingUIBorder += ChangingArrow;
		_giveAllObjectsToManagers = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>();
		_arrowType = _giveAllObjectsToManagers.player.GetComponent<PlayerShoot>();
		_UIBorder  = _giveAllObjectsToManagers.showCurrentAmmo;
		
		for(int i = 0; i < _UIBorder.transform.childCount; i++)
		{
			_UIBorder.transform.GetChild(i).gameObject.SetActive(false);
			_UIBorder.transform.GetChild(0).gameObject.SetActive(true);
		}
	}
	
	void OnDisable()
	{
		PlayerShoot.isChangingUIBorder -= ChangingArrow;
	}

	void ChangingArrow () {
		for(int i = 0; i < _UIBorder.transform.childCount; i++)
		{
			_UIBorder.transform.GetChild(i).gameObject.SetActive(false);
			_UIBorder.transform.GetChild(_arrowType.getArrowType()).gameObject.SetActive(true);
		}
	}
}
