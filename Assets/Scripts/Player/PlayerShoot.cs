using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public float fireRate;
	public string[] shootType;
	

	// Number of ammo for each shoot.
	private int _ammoTripleShoot;
	private int _ammoAttractShoot;

	//Current pos of the arrow shoot
	private int _currentPosArray = 0;

	private Object _arrowPrefab;
	private GameObject _shootedArrow;
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
		_arrowPrefab = (GameObject) Resources.Load("Prefabs/Arrow/NormalArrow");
		anim = GetComponent<Animator>();
	}

	// I create a new one each time that the player can shoot.
	void Update()
	{
		if(ManagerInput.Instance.isShooting()) // If i press the buttons to shoot
			Shoot();

		if(ManagerInput.Instance.isChangingSpellRight())
		{	_currentPosArray++;
			if(_currentPosArray < shootType.Length)
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
				_currentPosArray = shootType.Length - 1;

		}
	}

	void Shoot()
	{
		if (Time.time > fireRate + _lastShot)
		{
			anim.SetBool("isShooting", true);
			if(shootType[_currentPosArray] == "normal")
			{
				_shootedArrow = (GameObject) Instantiate(_arrowPrefab, this.transform.position, Quaternion.identity);
				_shootedArrow.GetComponent<ShootMovement>().setSpeed(speed);
			}

			if(shootType[_currentPosArray] == "tripleShoot" && _ammoTripleShoot > 0)
			{
				_ammoTripleShoot--;
				for(int j = 0; j < 3; j++)
				{
					_shootedArrow= (GameObject) Instantiate(_arrowPrefab, this.transform.position, Quaternion.identity);
					_shootedArrow.GetComponent<ShootMovement>().setSpeed(speed);
					_shootedArrow.GetComponent<ShootMovement>().directionShootedArrow = ShootMovement.DirectionShootedArrow.Up;
					
					if(j == 1)
						_shootedArrow.GetComponent<ShootMovement>().directionShootedArrow = ShootMovement.DirectionShootedArrow.UpRight;
					
					if(j == 2)
						_shootedArrow.GetComponent<ShootMovement>().directionShootedArrow = ShootMovement.DirectionShootedArrow.UpLeft;
				}
			}

			if(shootType[_currentPosArray] == "attractShoot" && _ammoAttractShoot > 0)
			{
				_ammoAttractShoot--;
				_shootedArrow = (GameObject) Instantiate(_arrowPrefab, this.transform.position, Quaternion.identity);
				_shootedArrow.GetComponent<ShootMovement>().setSpeed(speed);
				_shootedArrow.AddComponent("AttractEffect");
			}
			_lastShot = Time.time;
		}
		else
			anim.SetBool("isShooting", false);

	}
}
