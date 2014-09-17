using UnityEngine;
using System.Collections;

/************************************************************************************************
* On every orb
**  Make the orb spin on itself, and bounce on the wall of the game. 
** You can set a direction by instantiate it with DirecetionOrb
************************************************************************************************/

public class OrbBounce: MonoBehaviour 
{
	public float speedforce;
	public float speedRotate;

	public bool randomDirection;
	public enum DirectionOrb{UpLeft, UpRight, DownLeft, DownRight};
	public DirectionOrb directionOrb;

	private Vector2 _direction;
	private Rigidbody2D _rigidBody2D;

	//Value to make the ball goes up / down / left / right
	private float _randomX;
	private float _randomY;


	// Value to make randomly move the ball
	private float _random;
	private float _randomRound;


	void OnEnable () 
	{	
		_randomY = randomNumber(-1, 1);
		_randomX = randomNumber(-1, 1);

		switch(directionOrb)
		{
		case DirectionOrb.UpRight :
			_direction = new Vector2(-1, -1);
			break;
		case DirectionOrb.UpLeft:
			_direction = new Vector2(1, -1);	
			break;
		case DirectionOrb.DownRight :
			_direction = new Vector2(-1, 1);	
			break;
		case DirectionOrb.DownLeft :
			_direction = new Vector2(1, 1);	
			break;
		}

		_direction = new Vector2(_randomY, _randomX);	

		//get rigidBody2D component
		_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
		
		//set _direction of ball adding force
		setDirection(_direction);
	}

	private float randomNumber(float min, float max)
	{
		_random = Random.Range(min, max);
		_randomRound = Mathf.Round(_random * 100f) / 100f;

		if(_randomRound == 0)
		{ 
			_random = Random.Range(min, max);
			_randomRound = Mathf.Round(_random * 100f) / 100f;

			return _randomRound;
		}
		else
			return _randomRound;
	}
	
	private void setDirection(Vector2 in_direction)
	{		
		if(!_rigidBody2D)
			return;

		_direction = in_direction;
		
		//Normalize _directional vector
		_direction.Normalize();
		
		if(speedforce>=0)
			speedforce = 30;
		
		//add force in the _direction the ball bounces or starts
		_rigidBody2D.AddForce(_direction * speedforce);

	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		//reset force
		_rigidBody2D.velocity = Vector2.zero;
		
		//obtain the surface normal for a point on a collider 
		Vector2 CollisionNormal = collision.contacts[0].normal;
		
		//Reflects a vector off the plane defined by a normal.
		_direction = Vector3.Reflect(_direction, CollisionNormal);
		
		//apply new _direction adding force
		setDirection(_direction);
	}

	void Update()
	{
		// The ball rotate on itself.
		transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
	}
}
