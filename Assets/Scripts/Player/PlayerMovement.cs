using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
			
	public InputHandler inputHandler;
	public float speed;
	public float minSpeed;
	public float maxSpeed;

	private Vector2 _velocity;	

	void FixedUpdate () {
		this.movement();
	}
	
	void movement()
	{
		_velocity = new Vector2(Mathf.Lerp(minSpeed, maxSpeed, Time.time), 0) * speed;

		if(inputHandler.isMovingLeft())
			this.transform.Translate(-_velocity * Time.deltaTime);


		if(inputHandler.isMovingRight())
			this.transform.Translate(_velocity * Time.deltaTime);

		
	}
}