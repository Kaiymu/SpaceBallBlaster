using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public delegate void EndLevel();
	public static event EndLevel OnEndLevel;


	void Update () 
	{
		if(ManagerArray.Instance.getOrbArray().Count == 0)
			if(OnEndLevel != null)
			{
				Time.timeScale = 0;
				OnEndLevel();
			}
	}
}
