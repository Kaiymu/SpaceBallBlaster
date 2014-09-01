using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public float fireRate;
	public string[] shootType;
	public GameObject arrowPrefab;

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
	List<GameObject> arrows;


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
		anim = GetComponent<Animator>();
	}

	void Start()
	{
		arrows = new List<GameObject>();
		for(int i = 0; i < pooledAmmount; i++)
		{
			GameObject o = (GameObject) Instantiate(arrowPrefab);
			o.SetActive(false);
			arrows.Add(o);
		}
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
				for(int i = 0; i < arrows.Count; i++)
				{
					if(!arrows[i].activeInHierarchy)
					{
						arrows[i].transform.position = transform.position;
						arrows[i].transform.rotation = Quaternion.identity;
						arrows[i].GetComponent<ArrowMovement>().setSpeed(speed);
						arrows[i].SetActive(true);
						break;
					}
				}
			}

			if(shootType[_currentPosArray] == "tripleShoot" && _ammoTripleShoot > 0)
			{
				_ammoTripleShoot--;
				for(int j = 0; j < 3; j++)
				{
					for(int i = 0; i < arrows.Count; i++)
					{
						if(!arrows[i].activeInHierarchy)
						{
							arrows[i].transform.position = transform.position;
							arrows[i].transform.rotation = Quaternion.identity;
							arrows[i].GetComponent<ArrowMovement>().setSpeed(speed);
							arrows[i].GetComponent<ArrowMovement>().directionShootedArrow = ArrowMovement.DirectionShootedArrow.Up;
						
							if(j == 1)
								arrows[i].GetComponent<ArrowMovement>().directionShootedArrow = ArrowMovement.DirectionShootedArrow.UpRight;
							
							if(j == 2)
								arrows[i].GetComponent<ArrowMovement>().directionShootedArrow = ArrowMovement.DirectionShootedArrow.UpLeft;

							arrows[i].SetActive(true);
							break;
						}
					}
				}
			}

			if(shootType[_currentPosArray] == "attractShoot" && _ammoAttractShoot > 0)
			{
				_ammoAttractShoot--;

				for(int i = 0; i < arrows.Count; i++)
				{
					if(!arrows[i].activeInHierarchy)
					{
						arrows[i].transform.position = transform.position;
						arrows[i].transform.rotation = Quaternion.identity;
						arrows[i].GetComponent<ArrowMovement>().setSpeed(speed);
						arrows[i].AddComponent("AttractEffect");
						arrows[i].SetActive(true);
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
