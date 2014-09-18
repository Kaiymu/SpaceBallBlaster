using UnityEngine;
using System.Collections;

public class DisplayAmmo : MonoBehaviour {
	// To display the numbers of arrows left for the player
	private GameObject _displayArrayHook;
	private GameObject _displayArrayTripleArrow;
	
	private PlayerShoot _ammo;
	private GiveAllObjectsToManagers _giveAllObjectsToManagers;

	private bool _isInMenu;

	void OnEnable()
	{
		PlayerShoot.isChangingArrow += ChangingArrow;
	
		_giveAllObjectsToManagers = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>();
		_displayArrayHook = _giveAllObjectsToManagers.UIArrayArrowHook;
		_displayArrayTripleArrow = _giveAllObjectsToManagers.UIArrayArrowTriple;
		_ammo = _giveAllObjectsToManagers.player.GetComponent<PlayerShoot>();
		
		for(int i = 0; i < _displayArrayHook.transform.childCount; i++)
		{
			_displayArrayHook.transform.GetChild(i).gameObject.SetActive(false);
		}
		
		for(int i = 0; i < _displayArrayTripleArrow.transform.childCount; i++)
		{
			_displayArrayTripleArrow.transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	void OnDisable()
	{
		PlayerShoot.isChangingArrow -= ChangingArrow;
	}

	void ChangingArrow()
	{
		// Make all disapear, and just let appear the number of ammo that the player have for each ammo.
		for(int i = 0; i < _displayArrayHook.transform.childCount; i++)
		{
			_displayArrayHook.transform.GetChild(i).gameObject.SetActive(false);
		}

		for(int i = 0; i < _ammo.getAmmoAttractShoot(); i++)
		{
			_displayArrayHook.transform.GetChild(i).gameObject.SetActive(true);
		}

		for(int i = 0; i < _displayArrayTripleArrow.transform.childCount; i++)
		{
			_displayArrayTripleArrow.transform.GetChild(i).gameObject.SetActive(false);
		}
		
		for(int i = 0; i < _ammo.getAmmoTripleShoot(); i++)
		{
			_displayArrayTripleArrow.transform.GetChild(i).gameObject.SetActive(true);
		}
	}
}