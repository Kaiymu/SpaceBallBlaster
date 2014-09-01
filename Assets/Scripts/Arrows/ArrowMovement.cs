using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

	private float _speed;

	public enum DirectionShootedArrow{Up, UpLeft, UpRight};
	public DirectionShootedArrow directionShootedArrow;

	private Vector2 _direction;

	void Start()
	{
		_direction = Vector2.up;
		switch(directionShootedArrow)
		{
			case DirectionShootedArrow.Up : 		
			_direction = Vector2.up;
			break;
			case DirectionShootedArrow.UpLeft :
				_direction = new Vector2(-1, 1);
			break;
			case DirectionShootedArrow.UpRight :
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
