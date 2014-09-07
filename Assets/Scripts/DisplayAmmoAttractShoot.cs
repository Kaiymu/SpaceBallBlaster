using UnityEngine;
using System.Collections;

public class DisplayAmmoAttractShoot : MonoBehaviour {
	
	public GameObject player;

	// To display the numbers of arrows left for the player
	public GameObject[] displayArrayHook;
	public GameObject[] displayArrayTripleArrow;

	private PlayerShoot _ammo;
	// Use this for initialization
	void Start () {
		_ammo = player.GetComponent<PlayerShoot>();
		//this.guiText.text = "toto";

		for(int i = 0; i < displayArrayHook.Length; i++)
		{
			displayArrayHook[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
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