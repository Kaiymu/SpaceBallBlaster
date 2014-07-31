using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public float fireRate;

	public int ammoTripleShoot;
	public int ammoAttractShoot;
	
	public string[] shootTypeTest;

	private int _currentPosArray = 0;

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

		if(ManagerInput.Instance.isChangingSpellRight())
		{	_currentPosArray++;
			if(_currentPosArray < shootTypeTest.Length)
				Debug.Log ("");
			else 
				_currentPosArray = 0;
		}

		if(ManagerInput.Instance.isChangingSpellLeft())
		{
			_currentPosArray--;
			if(_currentPosArray >= 0)
				Debug.Log ("");
			else 
				_currentPosArray = shootTypeTest.Length - 1;

		}
	}

	void Shoot()
	{
		if (Time.time > fireRate + _lastShot)
		{
			// Faire une boucle ici, et dire que si la valeur de i string = au tir, alors le mec peu tirer.
			if(shootTypeTest[_currentPosArray] == "normal")
			{
				_shootedBall = (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
				_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
			}

			if(shootTypeTest[_currentPosArray] == "tripleShoot" && ammoTripleShoot > 0)
			{
				ammoTripleShoot--;
				for(int j = 0; j < 3; j++)
				{
					_shootedBall= (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
					_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
					_shootedBall.GetComponent<ShootMovement>().directionShootedBall = ShootMovement.DirectionShootedBall.Up;
					
					if(j == 1)
						_shootedBall.GetComponent<ShootMovement>().directionShootedBall = ShootMovement.DirectionShootedBall.UpRight;
					
					if(j == 2)
						_shootedBall.GetComponent<ShootMovement>().directionShootedBall = ShootMovement.DirectionShootedBall.UpLeft;
				}
			}

			Debug.Log (shootTypeTest[_currentPosArray]);
			if(shootTypeTest[_currentPosArray] == "attractShoot" && ammoAttractShoot > 0)
			{
				Debug.Log ("toto");
				ammoAttractShoot--;
				_shootedBall = (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
				_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
				_shootedBall.AddComponent("AttractEffect");
			}
			_lastShot = Time.time;
		}
	}
	
}
