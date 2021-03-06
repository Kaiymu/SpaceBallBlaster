﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/************************************************************************************************
* On the player
**  A script that allows the player to shoot pooled arrows, and change his ammo.
************************************************************************************************/

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public string[] shootType;
	public GameObject[] arrowPrefab;

	// Event to move the UI when the player change his arrow
	public delegate void ChangeArrow();
	public static event ChangeArrow isChangingUIBorder;
	public static event ChangeArrow isChangingArrow;

	// Number of ammo for each shoot.
	private int _ammoTripleShoot;
	private int _ammoAttractShoot;

	//Current position of the ammo in the array.
	private int _currentPosArray = 0;
	
	private GameObject _shootedArrow;
	private ArrowMovement _shootSpeed;

	//Pool object
	public int pooledAmmount = 5;
	private List<GameObject> _arrows;

	private bool _canShoot = true;
	
	private Animator anim;
	
	private float timeShoot = 0f;
	private float fireRate = 1f;

	// Temporary value to know if the number of ammo exced 4 or not.
	private float tempAmmoTripleShoot;
	private float tempAmmoAttractShoot;

	private ManagerInput _managerInput;

	public int getAmmoTripleShoot()
	{
		return _ammoTripleShoot;
	}

	// Called in PowerUp scripts, to set the ammmout. Allow an event to trigger and display the number of arrow in the UI.
	public void setAmmoTripleShoot(int _ammo)
	{
		tempAmmoTripleShoot = _ammoTripleShoot + _ammo;

		if(tempAmmoTripleShoot >= 4)
			_ammoTripleShoot = 4;
		else
			_ammoTripleShoot += _ammo;

		isChangingArrow();
	}

	public int getAmmoAttractShoot()
	{
		return _ammoAttractShoot;
	}
	
	public void setAmmoAttractShoot(int _ammo)
	{
		tempAmmoAttractShoot = _ammoAttractShoot + _ammo;

		if(tempAmmoAttractShoot >= 4)
			_ammoAttractShoot = 4;
		else
			_ammoAttractShoot += _ammo;

		isChangingArrow();
	}

	public int getArrowType()
	{
		return _currentPosArray;
	}

	public float getLastShot()
	{
		return timeShoot;
	}
	
	// I get the ball from the Resouces folder
	void Awake()
	{	
		_managerInput = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerInput>();
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
		// To know when the player can shoot.
		timeShoot += Time.deltaTime;

		if(_canShoot)
		{
			if(_managerInput.isShooting()) // If i press the buttons to shoot
				Shoot();
			if(_managerInput.isChangingAmmoRight())
			{	_currentPosArray++;
				if(_currentPosArray < shootType.Length)
					Debug.Log ("");
				else 
					_currentPosArray = 0;
				isChangingArrow();
				isChangingUIBorder();
			}

			if(_managerInput.isChangingAmmoLeft())
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
	{	
		if (fireRate < timeShoot)
		{   
			timeShoot = 0f;
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
							{	
								_arrows[i].GetComponent<ArrowMovement>().directionShootedArrow = ArrowMovement.DirectionShootedArrow.UpRight;
							}
							
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
		}
		else
			anim.SetBool("isShooting", false);
	}
}
