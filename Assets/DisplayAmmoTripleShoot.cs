using UnityEngine;
using System.Collections;

public class DisplayAmmoTripleShoot : MonoBehaviour {

	public GameObject playerAmmoTripleShoot;

	private int _ammoTripleShoot;

	// Use this for initialization
	void Start () {

	}

	void Update()
	{
		this.guiText.text = "x" + _ammoTripleShoot.ToString();
	}

}
