using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArray : MonoBehaviour {

	private List<GameObject> _spikkedArray;
	private List<GameObject> _powerUp;


	public static ManagerArray Instance { get; private set;}
	void Awake()
	{
		_spikkedArray = new List<GameObject>();
		_powerUp = new List<GameObject>();

		if(Instance != null && Instance != this)
			Destroy(gameObject);

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public List<GameObject> getSpikkedArray()
	{
		return _spikkedArray;
	}
	
	public void addSpikkedToArray(GameObject spikkedBall)
	{
		_spikkedArray.Add(spikkedBall);
	}

	public void removeSpikkedFromArray(GameObject spikkedBall)
	{
		_spikkedArray.Remove(spikkedBall);
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
