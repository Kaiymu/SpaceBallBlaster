using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ManagerPowerUp : MonoBehaviour {
	
	public static ManagerPowerUp Instance { get; private set;}

	public string powerUpBasePath = "Prefabs/PowerUp/base/";

	private GameObject _powerUpBase;
	private Transform _childPowerUpBase;

	void Awake()
	{
		_powerUpBase = (GameObject) Resources.Load(powerUpBasePath+"PowerUp_Base");

		// Looping throught my parent gameobject to retrieve all the childs.
		for(int i = 0; i < _powerUpBase.transform.childCount; i++)
		{
			_childPowerUpBase = _powerUpBase.transform.GetChild(i);
			ManagerArray.Instance.addPowerUpToArray(_childPowerUpBase.gameObject);
		}

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