using UnityEngine;
using System.Collections;

public class ManagerPlatform : MonoBehaviour {


	public GameObject[] buttons;
	// Use this for initialization
	void Start () {
		#if UNITY_STANDALONE_WIN
			for(int i = 0; i < buttons.Length; i++)
			{
				buttons[i].SetActive(false);
			}
		#endif
	}
}
