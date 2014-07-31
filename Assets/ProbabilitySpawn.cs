﻿using UnityEngine;
using System.Collections;

public class ProbabilitySpawn : MonoBehaviour {

	private float _randomNumber;

	public static ProbabilitySpawn Instance {get; private set;}

	void Awake()
	{
		if(Instance != null && Instance != this)
			Destroy(gameObject);
	
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public bool spawnGameobjects(float _percentApprearing)
	{
		_randomNumber = Random.Range(1, 100);

		if(_randomNumber < _percentApprearing)
			return true;
		else
			return false;
	}
}
