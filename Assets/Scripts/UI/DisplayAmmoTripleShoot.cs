using UnityEngine;
using System.Collections;

public class DisplayAmmoTripleShoot : MonoBehaviour {

	public GameObject player;
	private PlayerShoot _ammo;
	// Use this for initialization
	void Start () {
		_ammo = player.GetComponent<PlayerShoot>();
		//this.guiText.text = "toto";
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = _ammo.getAmmoTripleShoot() + "";
	}
}