using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
public class ManagerPowerUp : MonoBehaviour {
	
	public static ManagerPowerUp Instance { get; private set;}

	public string powerUpBasePath = "Prefabs/PowerUp/base";

	private GameObject _powerUpLife;
	private GameObject _powerUpTripleShoot;
	private GameObject _powerUpAttractShoot;

	void Awake()
	{
		// A faire mieux parce que caca
		_powerUpLife         = (GameObject) Resources.Load("Prefabs/PowerUp/PowerUp_Life");
		_powerUpTripleShoot  = (GameObject) Resources.Load("Prefabs/PowerUp/PowerUp_TripleShoot");
		_powerUpAttractShoot = (GameObject) Resources.Load("Prefabs/PowerUp/PowerUp_Attract");

		ManagerArray.Instance.addPowerUpToArray(_powerUpLife);
		ManagerArray.Instance.addPowerUpToArray(_powerUpTripleShoot);
		ManagerArray.Instance.addPowerUpToArray(_powerUpAttractShoot);


		if(Instance != null && Instance != this)
			Destroy(gameObject);


		Instance = this;

		DontDestroyOnLoad(gameObject);
	}

	public void movementPowerUps(GameObject me, float speed)
	{
		me.transform.Translate(new Vector2(0, -speed) * Time.deltaTime);
	}
}