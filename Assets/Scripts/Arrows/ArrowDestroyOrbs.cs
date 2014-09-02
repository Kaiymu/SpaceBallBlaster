using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowDestroyOrbs : MonoBehaviour {
	
	private int _numberOrbs;
	private int _chanceSpawn;
	
	private GameObject _randomPowerUp;
	private List<GameObject> _listPowerUp;
	private List<GameObject> _arrayOrb;
	
	void Start()
	{	
		_arrayOrb = ManagerPool.Instance.getOrb();
		_chanceSpawn = ManagerDifficulty.Instance.getBonusChanceSpawn();
		_numberOrbs =  ManagerDifficulty.Instance.getNumberSpikkedBalls();
		_listPowerUp = ManagerArray.Instance.getPowerUp();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Wall")
			this.gameObject.SetActive(false);
		
		if(col.transform.tag == "OrbDarkness")
		{
			instantiateOrbs(_numberOrbs, col.gameObject);
			
			if(ManagerProbabilitySpawn.Instance.spawnGameobjects(_chanceSpawn))
			{
				_randomPowerUp = _listPowerUp[Random.Range(0, _listPowerUp.Count)];
				GameObject o = (GameObject) Instantiate(_randomPowerUp, this.transform.position, Quaternion.identity);
				o.GetComponent<PowerUpSetSpeed>().speed = 1;
			}
			
			ManagerArray.Instance.removeOrbFromArray(col.gameObject);
			col.gameObject.SetActive(false);
			this.gameObject.SetActive(false);
		}
		else if(col.transform.tag == "OrbIce")
		{
			ManagerArray.Instance.removeOrbFromArray(col.gameObject);
			col.gameObject.SetActive(false);
			this.gameObject.SetActive(false);
		}
	}


	void instantiateOrbs(int number, GameObject col)
	{
		OrbSize.Size sizeOrb = col.GetComponent<OrbSize>().sizeOrb;

		// If the ball is really small or if it's a ice ball, we destroy it.
		if(sizeOrb == OrbSize.Size.smallSize)
			return;
		else
		{
			for(int i = 0; i < number; i++)
			{
				for(int j = 0; j < _arrayOrb.Count; j++)
				{
					GameObject randomOrb = _arrayOrb[Random.Range(0, _arrayOrb.Count)];

					if(!randomOrb.activeInHierarchy)
					{
						if(sizeOrb == OrbSize.Size.normalSize) // If it's normal, we instantiate a mid ball.
						{
							if(i == 0)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpLeft;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
								randomOrb.SetActive(true);
								break;
							}
							
							if(i == 1)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpRight;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
								randomOrb.SetActive(true);
								break;
							}
							
							if(i == 2)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownLeft;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
								randomOrb.SetActive(true);
								break;
							}
							
							if(i == 3)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownRight;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
								randomOrb.SetActive(true);
								break;
							}
							
						}	
						
						if(sizeOrb == OrbSize.Size.midSize) // If it's mid, we instantiate a small ball.
						{
							// Bug de malade ici, plz
							if(i == 0)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpLeft;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
								randomOrb.SetActive(true);
								break;
							}
							
							if(i == 1)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpRight;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
								randomOrb.SetActive(true);
								break;
							}
							
							if(i == 2)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownLeft;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
								randomOrb.SetActive(true);
								break;
							}
							
							if(i == 3)
							{
								randomOrb.transform.position = this.transform.position;
								randomOrb.transform.rotation = Quaternion.identity;
								randomOrb.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownRight;
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
								randomOrb.SetActive(true);
								break;

							}
						}
					}
				}
			}
		}
	}
}
