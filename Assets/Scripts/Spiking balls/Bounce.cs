using UnityEngine;
using System.Collections;

public class Bounce: MonoBehaviour 
{
	public float speedforce;
	public float speedRotate;

	public enum DirectionBall{UpLeft, UpRight, DownLeft, DownRight};
	public DirectionBall directionBall;

	private Vector2 _direction;
	private Rigidbody2D _rigidBody2D;

	void Start () 
	{	
		switch(directionBall)
		{
			case DirectionBall.UpLeft :
				_direction = new Vector2(-1, -1);
			break;
			case DirectionBall.UpRight :
				_direction = new Vector2(1, -1);	
			break;
			case DirectionBall.DownLeft :
				_direction = new Vector2(-1, 1);	
			break;
			case DirectionBall.DownRight :
				_direction = new Vector2(1, 1);	
			break;
		}

		//get rigidBody2D component
		_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
		
		//set _direction of ball adding force
		set_direction(_direction);
	}
	
	private void set_direction(Vector2 in_direction)
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
		set_direction(_direction);
	}

	void Update()
	{
		// The ball rotate on herself.
		transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
	}
}
