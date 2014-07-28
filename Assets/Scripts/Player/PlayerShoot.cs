using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public InputHandler inputHandler;
	public float speed;
	public float fireRate;

	private Object _ballPrefab;
	private ShootMovement _shootSpeed;
	private float _lastShot = 0.0f;

	// I get the ball from the Resouces folder
	void Awake()
	{	
		_ballPrefab = (GameObject) Resources.Load("Prefabs/Shooted balls/Shoot");
	}

	// I create a new one each time that the player can shoot.
	void Update()
	{
		if(inputHandler.isShooting()) // If i press the buttons to shoot
			Shoot();

	}

	void Shoot()
	{
		if (Time.time > fireRate + _lastShot)
		{
			GameObject o = (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
			o.GetComponent<ShootMovement>().setSpeed(speed);
			_lastShot = Time.time;
		}
	}
	
}
