using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
			
	public float speed;
	public float minSpeed;
	public float maxSpeed;

	private float speedAnim = 5;
	private Animator anim;
	
	private Vector2 _velocity;	

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate () {
		this.movement();
	}
	
	void movement()
	{	
		_velocity = new Vector2(Mathf.Lerp(minSpeed, maxSpeed, Time.time), 0) * speed;

		if(ManagerInput.Instance.isMovingLeft())
		{
			this.transform.Translate(-_velocity * Time.deltaTime);
			anim.SetBool("walk_left", true);
		}
		else
			anim.SetBool("walk_left", false);

		if(ManagerInput.Instance.isMovingRight())
		{
			this.transform.Translate(_velocity * Time.deltaTime);
			anim.SetBool("walk_right", true);
		}
		else
			anim.SetBool("walk_right", false);
	}
	
}