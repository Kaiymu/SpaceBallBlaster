using UnityEngine;
using System.Collections;

public class DisplayAmmo : MonoBehaviour {
	
	public GameObject player;

	// To display the numbers of arrows left for the player
	public GameObject[] displayArrayHook;
	public GameObject[] displayArrayTripleArrow;

	private PlayerShoot _ammo;

	void OnEnable()
	{
		PlayerShoot.isChangingArrow += ChangingArrow;
	}

	void OnDisable()
	{
		PlayerShoot.isChangingArrow -= ChangingArrow;
	}

	// Use this for initialization
	void Start () {
		_ammo = player.GetComponent<PlayerShoot>();
		for(int i = 0; i < displayArrayHook.Length; i++)
		{
			displayArrayHook[i].SetActive(false);
		}

		for(int i = 0; i < displayArrayTripleArrow.Length; i++)
		{
			displayArrayTripleArrow[i].SetActive(false);
		}
	}

	void ChangingArrow()
	{
		// Make all disapear, and just let appear the number of ammo that the player have for each ammo.
		for(int i = 0; i < displayArrayHook.Length; i++)
		{
			displayArrayHook[i].SetActive(false);
		}

		for(int i = 0; i < _ammo.getAmmoAttractShoot(); i++)
		{
			displayArrayHook[i].SetActive(true);
		}

		for(int i = 0; i < displayArrayTripleArrow.Length; i++)
		{
			displayArrayTripleArrow[i].SetActive(false);
		}
		
		for(int i = 0; i < _ammo.getAmmoTripleShoot(); i++)
		{
			displayArrayTripleArrow[i].SetActive(true);
		}
	}
}