using UnityEngine;
using System.Collections;

public class ManagerDifficulty : MonoBehaviour {

	public static ManagerDifficulty Instance {get; private set;}

	public enum Difficulty {easy, normal, hard};
	public Difficulty difficulty;

	//PlayerLife
	private int _playerLife;

	// PowerUpLife, PowerUpTripleShoot, PowerUpAttract
	private int _ammoLife;
	private int _ammoTripleShoot;
	private int _ammoAttractShoot;

	// Chance spawn DestroySpikkingBalls
	private int _bonusChanceSpawn;
	private int _numberSpikkedBalls;
	
	void Awake()
	{
		if(Instance != null && Instance != this)
			Destroy(gameObject);

		Instance = this;
		DontDestroyOnLoad(gameObject);

		switch(difficulty)
		{
			case Difficulty.easy : 
				_playerLife = 10;
				_ammoLife = 3;
				_ammoTripleShoot = 5;
				_ammoAttractShoot = 3;
				_bonusChanceSpawn = 50;
				_numberSpikkedBalls = 2;
			break;

			case Difficulty.normal :
				_playerLife = 6;
				_ammoLife = 2;
				_ammoTripleShoot = 4;
				_ammoAttractShoot = 2;
				_bonusChanceSpawn = 33;
				_numberSpikkedBalls = 3;
			break;

			case Difficulty.hard : 
				_playerLife = 4;
				_ammoLife = 1;
				_ammoTripleShoot = 3;
				_ammoAttractShoot = 1;
				_bonusChanceSpawn = 25;
				_numberSpikkedBalls = 4;
			break;
		}
	}

	public int getPlayerLife()
	{
		return _playerLife;
	}

	public int getAmmoLife()
	{
		return _ammoLife;
	}

	public int getAmmoTripleShoot()
	{
		return _ammoTripleShoot;
	}

	public int getAmmoAttractShoot()
	{
		return _ammoAttractShoot;
	}

	public int getBonusChanceSpawn()
	{
		return _bonusChanceSpawn;
	}

	public int getNumberSpikkedBalls()
	{
		return _numberSpikkedBalls;
	}
}
