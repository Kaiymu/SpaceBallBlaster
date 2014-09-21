using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private bool _isInGame;

	public bool IsInGame()
	{
		return _isInGame;
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// When the level change
	void OnLevelWasLoaded(int level) {

		// In game make a component that call all the others
		if(GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers") != null)
		{
			this.GetComponent<ManagerColor>().enabled = true;
			this.GetComponent<ManagerProbabilitySpawn>().enabled = true;
			this.GetComponent<ManagerDifficulty>().enabled = true;
			this.GetComponent<ActiveStartObject>().enabled = true;
			this.GetComponent<ManagerPlatform>().enabled = true;
			this.GetComponent<ManagerPool>().enabled = true;
			this.GetComponent<ManagerPowerUp>().enabled = true;
			this.GetComponent<ManagerMenu>().enabled = true;
			this.GetComponent<DetectBoundaries>().enabled = true;
			this.GetComponent<DisplayAmmo>().enabled = true;
			this.GetComponent<SetPositionBorderArrowType>().enabled = true;
			this.GetComponent<ManagerArray>().enabled = true;
		}
		else // In main menu / levels selection
		{
			this.GetComponent<ManagerColor>().enabled = false;
			this.GetComponent<ManagerProbabilitySpawn>().enabled = false;
			this.GetComponent<ManagerDifficulty>().enabled = false;
			this.GetComponent<ActiveStartObject>().enabled = false;
			this.GetComponent<ManagerPlatform>().enabled = false;
			this.GetComponent<ManagerPool>().enabled = false;
			this.GetComponent<ManagerPowerUp>().enabled = false;
			this.GetComponent<ManagerMenu>().enabled = false;
			this.GetComponent<DetectBoundaries>().enabled = false;
			this.GetComponent<DisplayAmmo>().enabled = false;
			this.GetComponent<SetPositionBorderArrowType>().enabled = false;
			this.GetComponent<ManagerArray>().enabled = false;
		}
	}
}
