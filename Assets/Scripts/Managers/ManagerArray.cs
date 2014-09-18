using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArray : MonoBehaviour {

	private List<GameObject> _orbArray;
	private List<GameObject> _powerUp;

	void OnEnable()
	{
		_orbArray = new List<GameObject>();
		_powerUp = new List<GameObject>();

		this.gameObject.GetComponent<ManagerPowerUp>().OnGlobalEnable();
		this.gameObject.GetComponent<ActiveStartObject>().OnGlobalEnable();
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
