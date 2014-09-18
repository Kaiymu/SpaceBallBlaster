using UnityEngine;
using System.Collections;

public class ManagerMenu : MonoBehaviour {

	public delegate void EndLevel();
	public static event EndLevel OnEndLevel;

	public delegate void PauseGame();
	public static event PauseGame OnPauseGame;

	public delegate void UnPauseGame();
	public static event UnPauseGame OnUnPauseGame;

	private GameObject _elementMenuToShow, _elementGameOverToShow, _elementWinToShow;

	private GameObject _player;

	// If the player can die or not.
	public bool debug;

	// If the game over menu / win menu is displayed, we don't have the pause menu. 
	private bool _canPause = true;
	private bool _displayMenuOnce = true;

	private ManagerArray _managerArray;
	private GiveAllObjectsToManagers _giveAllObjectsToManagers;
	
	void OnEnable()
	{
		_managerArray = this.GetComponent<ManagerArray>();
		_giveAllObjectsToManagers = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>();
		_player = _giveAllObjectsToManagers.player;
		_elementMenuToShow = _giveAllObjectsToManagers.menuGame;
		_elementGameOverToShow = _giveAllObjectsToManagers.menuLoose;
		_elementWinToShow = _giveAllObjectsToManagers.menuWin;
		_displayMenuOnce = true;
	}

	void Update () 
	{
		PausingGame();
		GoingMainMenu();
		EndGame();
	}

	void PausingGame()
	{
		if(_canPause){
			if(ManagerInput.Instance.isPausing()){
				//Game is paused
				if(Time.timeScale != 0){
					Time.timeScale = 0;
					OnPauseGame();
					for(int i = 0; i < _elementMenuToShow.transform.childCount; i++)
					{
						_elementMenuToShow.transform.GetChild(i).gameObject.SetActive(true);
						
					}
				}
				else {
					Time.timeScale = 1; 	// Game is playing
					OnUnPauseGame();
					for(int i = 0; i < _elementMenuToShow.transform.childCount; i++)
					{
						_elementMenuToShow.transform.GetChild(i).gameObject.SetActive(false);	
					}
				}
			}
		}
	}

	void GoingMainMenu()
	{
		if(ManagerInput.Instance.goingBackMainMenu()) {

			Application.LoadLevel("MainMenu");
		}
	}

	void EndGame()
	{
		if(_managerArray.getOrbArray().Count == 0){
			if(OnEndLevel != null && _displayMenuOnce){
				_displayMenuOnce = false;
				Time.timeScale = 0;
				_canPause = false;
				OnEndLevel();
				
				for(int i = 0; i < _elementWinToShow.transform.childCount; i++)
				{
					_elementWinToShow.transform.GetChild(i).gameObject.SetActive(true);
				}
			}
		}
		
		
		if(!debug){
			if(_player.GetComponent<PlayerLife>().getLife() <= 0){
				Time.timeScale = 0;
				_canPause = false;
				OnEndLevel();

				for(int i = 0; i < _elementGameOverToShow.transform.childCount; i++)
				{
					_elementGameOverToShow.transform.GetChild(i).gameObject.SetActive(true);
				}
			}
		}
		
		if(ManagerInput.Instance.isQuitting()) {
			Application.Quit();
		}

	}
}
