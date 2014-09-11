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



	void Update () 
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

		if(ManagerArray.Instance.getOrbArray().Count == 0)
		{
			if(OnEndLevel != null)
			{
				Time.timeScale = 0;
				OnEndLevel();
			}
		}

		if(ManagerInput.Instance.isQuitting())
		{
			Application.Quit();
		}
	}
}
