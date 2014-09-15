using UnityEngine;
using System.Collections;

public class ActiveStartObject : MonoBehaviour {

	// A script to active the orbs in the beginning of the game.
	public GameObject[] objectToActive;

	void Start () {

		for(int i = 0; i < objectToActive.Length; i++)
		{
			objectToActive[i].SetActive(true);
		}
	}

}
