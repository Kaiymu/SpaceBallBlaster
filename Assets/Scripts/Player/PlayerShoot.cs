using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public float fireRate;
	public string[] shootType;
	public GameObject[] arrowPrefab;

	// Event to move the UI when the player change his arrow
	public delegate void ChangeArrow();
	public static event ChangeArrow isChangingUIBorder;
	public static event ChangeArrow isChangingArrow;

	// Number of ammo for each shoot.
	private int _ammoTripleShoot;
	private int _ammoAttractShoot;

	//Current pos of the arrow shoot
	private int _currentPosArray = 0;
	
	private GameObject _shootedArrow;
	private ArrowMovement _shootSpeed;
	private float _lastShot = 0.0f;

	//Pool object
	public int pooledAmmount = 5;
	private List<GameObject> _arrows;

	private bool _canShoot = true;
	
	private Animator anim;
	
	public int getAmmoTripleShoot()
	{
		return _ammoTripleShoot;
	}

	// Called in PowerUp scripts, to set the ammmout. Allow an event to trigger and display the number of arrow in the UI.
	public void setAmmoTripleShoot(int _ammo)
	{
		_ammoTripleShoot += _ammo;
		isChangingArrow();
	}

	public int getAmmoAttractShoot()
	{
		return _ammoAttractShoot;
	}
	
	public void setAmmoAttractShoot(int _ammo)
	{
		_ammoAttractShoot += _ammo;
		isChangingArrow();
	}

	public int getArrowType()
	{
		return _currentPosArray;
	}

	public float getLastShot()
	{
		return _lastShot;
	}

	// I get the ball from the Resouces folder
	void Awake()
	{	
		anim = GetComponent<Animator>();
	}

	void Start()
	{
		_arrows = new List<GameObject>();
		for(int i = 0; i < arrowPrefab.Length; i++)
		{
			for(int j = 0; j < pooledAmmount; j++)
			{
				GameObject o = (GameObject) Instantiate(arrowPrefab[i]);
				_arrows.Add(o);
			}
		}
	}

	// I create a new one each time that the player can shoot.
	void Update()
	{
		if(_canShoot)
		{
			if(ManagerInput.Instance.isShooting()) // If i press the buttons to shoot
				Shoot();

			if(ManagerInput.Instance.isChangingAmmoRight())
			{	_currentPosArray++;
				if(_currentPosArray < shootType.Length)
					Debug.Log ("");
				else 
					_currentPosArray = 0;
				isChangingArrow();
				isChangingUIBorder();
			}

			if(ManagerInput.Instance.isChangingAmmoLeft())
			{
				_currentPosArray--;
				if(_currentPosArray >= 0)
					Debug.Log ("");
				else 
					_currentPosArray = shootType.Length - 1;
				isChangingUIBorder();
			}
		}
	}

	void Shoot()
	{		Debug.Log (_lastShot);
		if (Time.time > fireRate + _lastShot)
		{
			anim.SetBool("isShooting", true);
			if(shootType[_currentPosArray] == "normal")
			{
				for(int i = 0; i < _arrows.Count; i++)
				{
					if(!_arrows[i].activeInHierarchy)
					{
						_arrows[i].transform.position = transform.position;
						_arrows[i].transform.rotation = Quaternion.identity;
						_arrows[i].GetComponent<ArrowMovement>().setSpeed(speed);
						_arrows[i].SetActive(true);
						break;
					}
				}
			}

			if(shootType[_currentPosArray] == "tripleShoot" && _ammoTripleShoot > 0)
			{
				_ammoTripleShoot--;

				for(int j = 0; j < 3; j++)
				{
					for(int i = 0; i < _arrows.Count; i++)
					{
						if(!_arrows[i].activeInHierarchy)
						{
							// An event that trigger to display the UI of the number of arrow.
							isChangingArrow();
							_arrows[i].transform.position = transform.position;
							_arrows[i].transform.rotation = Quaternion.identity;
							_arrows[i].GetComponent<ArrowMovement>().setSpeed(speed);
							_arrows[i].GetComponent<ArrowMovement>().directionShootedArrow = ArrowMovement.DirectionShootedArrow.Up;
						
							if(j == 1)
								_arrows[i].GetComponent<ArrowMovement>().directionShootedArrow = ArrowMovement.DirectionShootedArrow.UpRight;
							
							if(j == 2)
								_arrows[i].GetComponent<ArrowMovement>().directionShootedArrow = ArrowMovement.DirectionShootedArrow.UpLeft;

							_arrows[i].SetActive(true);
							break;
						}
					}
				}
			}

			if(shootType[_currentPosArray] == "attractShoot" && _ammoAttractShoot > 0)
			{
				_ammoAttractShoot--;

				for(int i = 0; i < _arrows.Count; i++)
				{
					if(_arrows[i].GetComponent<ArrowAttractEffect>() && !_arrows[i].activeInHierarchy)
					{
						// An event that trigger to display the UI of the number of arrow.
						isChangingArrow();
						_arrows[i].transform.position = transform.position;
						_arrows[i].transform.rotation = Quaternion.identity;
						_arrows[i].GetComponent<ArrowMovement>().setSpeed(speed);
						_arrows[i].SetActive(true);
						break;
					}
				}
			}
			_lastShot = Time.time;
		}
		else
			anim.SetBool("isShooting", false);

	}
}
