using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArray : MonoBehaviour {

	private List<GameObject> _orbArray;
	private List<GameObject> _powerUp;


	public static ManagerArray Instance { get; private set;}
	void Awake()
	{
		_orbArray = new List<GameObject>();
		_powerUp = new List<GameObject>();

		if(Instance != null && Instance != this)
			Destroy(gameObject);

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public List<GameObject> getOrbArray()
	{
		return _orbArray;
	}
	
	public void addOrbToArray(GameObject orb)
	{
		_orbArray.Add(orb);
	}

	public void removeOrbFromArray(GameObject orb)
	{
		_orbArray.Remove(orb);
	}

	public List<GameObject> getPowerUp()
	{
		return _powerUp;
	}
	
	public void addPowerUpToArray(GameObject powerUp)
	{
		_powerUp.Add(powerUp);
	}

	public void removePowerUpFromArray(GameObject powerUp)
	{
		_powerUp.Remove(powerUp);
	}
}
