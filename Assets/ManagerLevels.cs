using UnityEngine;
using System.Collections;

public class ManagerLevels : MonoBehaviour {
	
	public static ManagerLevels Instance {get; private set;}
	public string ListLevelSceneName;

	private float currentLevel;
	// Use this for initialization
	void Awake () 
	{
		if(Instance != null && Instance != this)
			Destroy(gameObject);
	
		Instance = this;
		DontDestroyOnLoad(gameObject);

		currentLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GoToMainMenu()
	{
		Application.LoadLevel("main_menu");
	}

	// Used in the main menu to go to the level list
	void GoToListLevels()
	{
		Application.LoadLevel(ListLevelSceneName);
	}

	// Called in the list level, when the players push a buttons to go to the level
	void GoToLevel(GameObject gameObjectLevel)
	{
		Application.LoadLevel(gameObjectLevel.name);
	}
}
