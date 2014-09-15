using UnityEngine;
using System.Collections;

public class ManagerMenu : MonoBehaviour {

	public delegate void EndLevel();
	public static event EndLevel OnEndLevel;

	public delegate void PauseGame();
	public static event PauseGame OnPauseGame;

	public delegate void UnPauseGame();
	public static event UnPauseGame OnUnPauseGame;

	public GameObject[] elementMenuToShow;
	public GameObject[] elementGameOverToShow;
	public GameObject[] elementVictoryToShow;

	public GameObject player;

	public bool debug;
	private bool _cantPause = false;
	
	void Update () 
	{
		if(_cantPause)
		{
			if(ManagerInput.Instance.isPausing())
			{
				//Game is paused
				if(Time.timeScale != 0)
				{
					Time.timeScale = 0;
					OnPauseGame();
					for(int i = 0; i < elementMenuToShow.Length; i++)
					{
						elementMenuToShow[i].SetActive(true);

					}
				}
				else
				{
					Time.timeScale = 1; 	// Game is playing
					OnUnPauseGame();
					for(int i = 0; i < elementMenuToShow.Length; i++)
					{
						elementMenuToShow[i].SetActive(false);
						
					}
				}
			}
		}

		if(ManagerArray.Instance.getOrbArray().Count == 0)
		{
			if(OnEndLevel != null)
			{
				Time.timeScale = 0;
				_cantPause = true;
				OnEndLevel();

				for(int i = 0; i < elementVictoryToShow.Length; i++)
				{
					elementVictoryToShow[i].SetActive(true);
				}
			}
		}


		if(!debug)
		{
			if(player.GetComponent<PlayerLife>().getLife() <= 0)
			{
				Time.timeScale = 0;
				_cantPause = true;
				OnEndLevel();
				for(int i = 0; i < elementGameOverToShow.Length; i++)
				{
					elementGameOverToShow[i].SetActive(true);
				}
			}
		}

		if(ManagerInput.Instance.isQuitting())
		{
			Application.Quit();
		}
	}
}
