using UnityEngine;
using System.Collections;

public class ManagerPowerUp : MonoBehaviour {
	
	public static ManagerPowerUp Instance { get; private set;}

	void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;

		DontDestroyOnLoad(gameObject);
	}

	public void movementPowerUps(GameObject me, float speed)
	{
		me.transform.Translate(new Vector2(0, -speed) * Time.deltaTime);
	}

}