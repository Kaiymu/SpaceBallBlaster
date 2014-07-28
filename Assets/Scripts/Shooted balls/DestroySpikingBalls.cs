using UnityEngine;
using System.Collections;

public class DestroySpikingBalls : MonoBehaviour {

	public int numberSpikkedBalls;
	public GameObject colorBlinkingManager;

	private GameObject _spikedBallPrefab;

	void Awake()
	{	
		_spikedBallPrefab = (GameObject) Resources.Load("Prefabs/Spikking Balls/SpikkingBalls");
	} 
	
	void OnCollisionEnter2D(Collision2D col)
	{	
		if(col.transform.tag == "SpikkedBalls")
		{
			instantiateSpikedBalls(numberSpikkedBalls, col.gameObject);
			Destroy(this.gameObject);
			Destroy(col.gameObject);
		}
	}

	void instantiateSpikedBalls(int number, GameObject col)
	{
		SpikkingBallsSize.Size sizeBall = col.GetComponent<SpikkingBallsSize>().sizeBall;

		// If the ball is really small, we destroy it.
		if(sizeBall == SpikkingBallsSize.Size.smallSize)
			return;
		else
		{
			for(int i = 0; i < number; i++)
			{
				GameObject o = (GameObject) Instantiate(_spikedBallPrefab, this.transform.position, Quaternion.identity);
				o.GetComponent<CollisionDamagePlayer>().blinkColor = colorBlinkingManager;
				if(sizeBall == SpikkingBallsSize.Size.normalSize) // If it's normal, we instantiate a mid ball.
				{
					if(i == 0)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.UpLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

					if(i == 1)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.UpRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

					if(i == 2)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.DownLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

					if(i == 3)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.DownRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.midSize;
					}

				}	

				else if(sizeBall == SpikkingBallsSize.Size.midSize) // If it's mid, we instantiate a small ball.
				{
					if(i == 0)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.UpLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}
					
					if(i == 1)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.UpRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}

					if(i == 2)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.DownLeft;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}
				
					if(i == 3)
					{
						o.GetComponent<Bounce>().directionBall = Bounce.DirectionBall.DownRight;
						o.GetComponent<SpikkingBallsSize>().sizeBall = SpikkingBallsSize.Size.smallSize;
					}
				}
			}
		}
	}
}
