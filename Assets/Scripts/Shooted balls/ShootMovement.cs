using UnityEngine;
using System.Collections;

public class ShootMovement : MonoBehaviour {

	private float _speed;
	
	public float getSpeed()
	{
		return _speed;
	}
	
	public void setSpeed(float speed)
	{
		_speed = speed;
	}

	void FixedUpdate () {

		this.transform.Translate(Vector2.up * _speed * Time.deltaTime);
	}
}
