using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public float fireRate;

	private int _ammoTripleShoot;
	private int _ammoAttractShoot;
	
	public string[] shootTypeTest;

	private int _currentPosArray = 0;

	private Object _ballPrefab;
	private GameObject _shootedBall;
	private ShootMovement _shootSpeed;
	private float _lastShot = 0.0f;

	private Animator anim;
	
	public int getAmmoTripleShoot()
	{
		return _ammoTripleShoot;
	}

	public void setAmmoTripleShoot(int _ammo)
	{
		_ammoTripleShoot += _ammo;
	}

	public int getAmmoAttractShoot()
	{
		return _ammoAttractShoot;
	}
	
	public void setAmmoAttractShoot(int _ammo)
	{
		_ammoAttractShoot += _ammo;
	}
	
	// I get the ball from the Resouces folder
	void Awake()
	{	
		_ballPrefab = (GameObject) Resources.Load("Prefabs/Shooted balls/Shoot");
		anim = GetComponent<Animator>();
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
			anim.SetBool("isShooting", true);
			if(shootTypeTest[_currentPosArray] == "normal")
			{
				_shootedBall = (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
				_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
			}

			if(shootTypeTest[_currentPosArray] == "tripleShoot" && _ammoTripleShoot > 0)
			{
				_ammoTripleShoot--;
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

			if(shootTypeTest[_currentPosArray] == "attractShoot" && _ammoAttractShoot > 0)
			{
				_ammoAttractShoot--;
				_shootedBall = (GameObject) Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
				_shootedBall.GetComponent<ShootMovement>().setSpeed(speed);
				_shootedBall.AddComponent("AttractEffect");
			}
			_lastShot = Time.time;
		}
		else
			anim.SetBool("isShooting", false);

	}
}
