using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroySpikingBalls : MonoBehaviour {
	
	public GameObject[] arrayOrbs;

	private int _numberSpikkedBalls;
	private int _chanceSpawn;

	private GameObject _spikedBallPrefab;
	private GameObject _randomPowerUp;
	private List<GameObject> _listPowerUp;

	void Start()
	{	
		_chanceSpawn = ManagerDifficulty.Instance.getBonusChanceSpawn();
		_numberSpikkedBalls =  ManagerDifficulty.Instance.getNumberSpikkedBalls();
		_listPowerUp = ManagerArray.Instance.getPowerUp();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{	
		if(col.transform.tag == "OrbDarkness")
		{
			instantiateSpikedBalls(_numberSpikkedBalls, col.gameObject);

			if(ProbabilitySpawn.Instance.spawnGameobjects(_chanceSpawn))
			{
				_randomPowerUp = _listPowerUp[Random.Range(0, _listPowerUp.Count)];
				GameObject o = (GameObject) Instantiate(_randomPowerUp, this.transform.position, Quaternion.identity);
				o.GetComponent<PowerUpSetSpeed>().speed = 1;
			}
			ManagerArray.Instance.removeSpikkedFromArray(col.gameObject);

			Destroy(this.gameObject);
			Destroy(col.gameObject);
		}
		else if(col.transform.tag == "OrbIce")
		{
			ManagerArray.Instance.removeSpikkedFromArray(col.gameObject);
			Destroy(this.gameObject);
			Destroy(col.gameObject);
		}
	}

	void instantiateSpikedBalls(int number, GameObject col)
	{
		SpikkingBallsSize.Size sizeBall = col.GetComponent<SpikkingBallsSize>().sizeBall;

		// If the ball is really small or if it's a ice ball, we destroy it.
		if(sizeBall == SpikkingBallsSize.Size.smallSize)
			return;
		else
		{
			for(int i = 0; i < number; i++)
			{
				GameObject randomOrb = arrayOrbs[Random.Range(0, 2)];
				                     
				GameObject o = (GameObject) Instantiate(randomOrb, this.transform.position, Quaternion.identity);
				if(sizeBall == SpikkingBallsSize.Size.normalSize) // If it's normal, we instantiate a mid ball.
				{
					if(i == 0)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.UpLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

					if(i == 1)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.UpRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

					if(i == 2)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.DownLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

					if(i == 3)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.DownRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

				}	

				else if(sizeBall == SpikkingBallsSize.Size.midSize) // If it's mid, we instantiate a small ball.
				{
					if(i == 0)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.UpLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}
					
					if(i == 1)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.UpRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}

					if(i == 2)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.DownLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}
				
					if(i == 3)
					{
						o.GetComponent<SpikkedBallBounce>().directionBall = SpikkedBallBounce.DirectionBall.DownRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}
				}
			}
		}
	}
}
