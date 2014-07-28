using UnityEngine;
using System.Collections;

public class DestroySpikingBalls : MonoBehaviour {

	private GameObject _spikedBallPrefab;
	void Awake()
	{	
		// Créer 3 prefabs différent, c'est quand meme mieux :).
		_spikedBallPrefab = (GameObject) Resources.Load("Prefabs/Spikking Balls/SpikkingBalls");
	} 
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "SpikkedBalls")
		{
			instantiateSpikedBalls(2, col.gameObject);
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

				}	
				// ya un bug ici.
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
				}
			}
		}
	}
}
