using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the arrow GameObject
**  Make the arrow move & rotate in function of a passed vector. 
************************************************************************************************/

public class ArrowMovement : MonoBehaviour {

	private float _speed;

	public enum DirectionShootedArrow{Up, UpLeft, UpRight};
	public DirectionShootedArrow directionShootedArrow;

	private Vector2 _direction;
	private float _angleZ;

	void OnEnable()
	{
		switch(directionShootedArrow)
		{
			case DirectionShootedArrow.Up : 		
				_direction = Vector2.up;
				_angleZ = transform.rotation.z;
			break;
			case DirectionShootedArrow.UpLeft :
				_direction = new Vector2(0, 1);
				_angleZ = 0.43f;
			break;
			case DirectionShootedArrow.UpRight :
				_direction = new Vector2(0, 1);	
				_angleZ = -0.43f;
			break;
		}

		transform.localRotation = new Quaternion(transform.rotation.x, transform.rotation.y, _angleZ, transform.rotation.w);                                            
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
