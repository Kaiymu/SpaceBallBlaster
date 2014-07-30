using UnityEngine;
using System.Collections;

public class ProbabilitySpawn : MonoBehaviour {

	private float _randomNumber;

	bool spawnGameobjects(float _percentApprearing)
	{
		_randomNumber = Random.Range(1, 100);

		if(_randomNumber < _percentApprearing)
			return true;
		else
			return false;
	}
}
