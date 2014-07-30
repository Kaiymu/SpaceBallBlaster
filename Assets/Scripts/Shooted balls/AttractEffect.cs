﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttractEffect : MonoBehaviour {

	public float strengthOfAttraction = 5.0f;
	public float maxGravityDistance = 4.0f;
	public float attractForce = 10.0f;

	private List<GameObject> _attractedFrom;
	private float _distance;
	private float _gravityAttract;
	private Vector2 _differencePlayerSpikked;
	
	void Start()
	{
		_attractedFrom = ManagerArray.Instance.getSpikkedArray();
	}

	// Attach automaticly to the ball if it's getting instantiated.
	void FixedUpdate()
	{
		foreach(GameObject spikkedBall in _attractedFrom)
		{
			_distance = Vector2.Distance(spikkedBall.transform.position, transform.position);

			// Calculating the distance between the shooted ball and the spikked balls.
			if(_distance <= maxGravityDistance)
			{
				_differencePlayerSpikked = spikkedBall.transform.position - transform.position;
				_gravityAttract = _distance / maxGravityDistance;

				// If if put _differencePlayerSpikked in negative, it repulse the balls, good to know.
				spikkedBall.rigidbody2D.AddForce(-_differencePlayerSpikked.normalized * _gravityAttract * attractForce);
			}

		}
	}
}