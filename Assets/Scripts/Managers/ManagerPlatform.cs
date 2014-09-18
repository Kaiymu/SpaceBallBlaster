using UnityEngine;
using System.Collections;

/************************************************************************************
* This script is to know when you're on mobile or computer, it hides mobile button on windows PC.
************************************************************************************/

public class ManagerPlatform : MonoBehaviour {
	
	private GameObject[] buttonsToHide;

	void OnEnable () {
		buttonsToHide = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>().phoneButtonsToHide;
		#if UNITY_STANDALONE_WIN
			for(int i = 0; i < buttonsToHide.Length; i++)
			{
				buttonsToHide[i].SetActive(false);
			}
		#endif
	}
}
