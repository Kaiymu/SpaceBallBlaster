using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public float fireRate;

	public enum ShootType {normal, tripleShoot, attractShoot};
	public ShootType shootType;

	private Object _ballPrefab;
	private GameObject _shootedBall;
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
		if(ManagerInput.Instance.isShooting()) // If i press the buttons to shoot
			Shoot();
	}

	void Shoot()
	{
		if (Time.time > fireRate + _lastShot)
		{
			switch(shootType)
			{
				// Instantiante one normal ball that goes up.
				case ShootType.normal : 
					_shootedBall = (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
					_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
				break; 

				// Instantite 3 balls, in 3 different directions (up, upLeft, upRight)
				case ShootType.tripleShoot :
					for(int i = 0; i < 3; i++)
					{
						_shootedBall= (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
						_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
						_shootedBall.GetComponent<ShootMovement>().directionShootedBall = ShootMovement.DirectionShootedBall.Up;
						
						if(i == 1)
							_shootedBall.GetComponent<ShootMovement>().directionShootedBall = ShootMovement.DirectionShootedBall.UpRight;
						
						if(i == 2)
							_shootedBall.GetComponent<ShootMovement>().directionShootedBall = ShootMovement.DirectionShootedBall.UpLeft;
					}

				break;
				case ShootType.attractShoot:
					_shootedBall = (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
					_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
					_shootedBall.AddComponent("AttractEffect");
				break;
			}
			_lastShot = Time.time;
		}
	}
	
}
