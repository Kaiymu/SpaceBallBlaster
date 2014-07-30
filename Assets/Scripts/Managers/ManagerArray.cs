using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArray : MonoBehaviour {

	private List<GameObject> spikkedArray;

	public static ManagerArray Instance { get; private set;}

	void Awake()
	{
		spikkedArray = new List<GameObject>();
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
	
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public List<GameObject> getSpikkedArray()
	{
		return spikkedArray;
	}
	
	public void addSpikkedToArray(GameObject spikkedBall)
	{
		spikkedArray.Add(spikkedBall);
	}

	public void removeSpikkedFromArray(GameObject spikkedBall)
	{
		spikkedArray.Remove(spikkedBall);
	}
}
