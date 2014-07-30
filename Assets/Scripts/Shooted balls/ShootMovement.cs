using UnityEngine;
using System.Collections;

public class ShootMovement : MonoBehaviour {

	private float _speed;

	public enum DirectionShootedBall{Up, UpLeft, UpRight};
	public DirectionShootedBall directionShootedBall;

	private Vector2 _direction;

	void Start()
	{
		_direction = Vector2.up;
		switch(directionShootedBall)
		{
			case DirectionShootedBall.Up : 		
			_direction = Vector2.up;
			break;
			case DirectionShootedBall.UpLeft :
				_direction = new Vector2(-1, 1);
			break;
			case DirectionShootedBall.UpRight :
				_direction = new Vector2(1, 1);	
			break;
		}
	}
	
	public float getSpeed()
	{
		return _speed;
	}
	
	public void setSpeed(float speed)
	{
		_speed = speed;
	}

	void FixedUpdate () 
	{
		this.transform.Translate(_direction * _speed * Time.deltaTime);
	}
}
