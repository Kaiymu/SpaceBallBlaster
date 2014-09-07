using UnityEngine;
using System.Collections;

public class ManagerMenu : MonoBehaviour {
	
	void Update () {
		if(ManagerInput.Instance.isPausing())
		{
			if(Time.timeScale != 0)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}
}
