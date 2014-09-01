using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowDestroyOrbs : MonoBehaviour {
	
	public GameObject[] arrayOrbs;

	private int _numberOrbs;
	private int _chanceSpawn;
	
	private GameObject _randomPowerUp;
	private List<GameObject> _listPowerUp;

	public int spawn = 10;
	private List<GameObject> _orbs;

	void Start()
	{	
		_orbs = new List<GameObject>();

		for(int i = 0; i < arrayOrbs.Length; i++)
		{
			for(int j = 0; j < spawn; j++)
			{
				GameObject o = Instantiate(arrayOrbs[i]) as GameObject;
				o.SetActive(false);
				_orbs.Add(o);
			}
		}
		_chanceSpawn = ManagerDifficulty.Instance.getBonusChanceSpawn();
		_numberOrbs =  ManagerDifficulty.Instance.getNumberSpikkedBalls();
		_listPowerUp = ManagerArray.Instance.getPowerUp();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{	
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
			Destroy(col.gameObject);
		}
		else if(col.transform.tag == "OrbIce")
		{
			ManagerArray.Instance.removeOrbFromArray(col.gameObject);
			Destroy(col.gameObject);
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
				GameObject randomOrb = arrayOrbs[Random.Range(0, 2)];
				                     
				GameObject o = (GameObject) Instantiate(randomOrb, this.transform.position, Quaternion.identity);
				if(sizeOrb == OrbSize.Size.normalSize) // If it's normal, we instantiate a mid ball.
				{
					if(i == 0)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpLeft;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
					}

					if(i == 1)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpRight;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
					}

					if(i == 2)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownLeft;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
					}

					if(i == 3)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownRight;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
					}

				}	

				else if(sizeOrb == OrbSize.Size.midSize) // If it's mid, we instantiate a small ball.
				{
					if(i == 0)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpLeft;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
					}
					
					if(i == 1)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.UpRight;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
					}

					if(i == 2)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownLeft;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
					}
				
					if(i == 3)
					{
						o.GetComponent<OrbBounce>().directionOrb = OrbBounce.DirectionOrb.DownRight;
						o.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
					}
				}
			}
		}
	}
}
