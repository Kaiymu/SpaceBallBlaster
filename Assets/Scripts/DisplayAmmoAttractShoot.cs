using UnityEngine;
using System.Collections;

public class DisplayAmmoAttractShoot : MonoBehaviour {
	
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
	}

	void ChangingArrow()
	{
		for(int i = 0; i < displayArrayHook.Length; i++)
		{
			displayArrayHook[i].SetActive(false);
		}

		for(int i = 0; i < _ammo.getAmmoAttractShoot(); i++)
		{
			displayArrayHook[i].SetActive(true);
		}
	}
}