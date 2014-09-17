using UnityEngine;
using System.Collections;

public class ActiveStartObject : MonoBehaviour {

	// A script to active the orbs in the beginning of the game.
	private GameObject _objectToActive;

	void OnEnable () {

		if(!this.GetComponent<isOnGame>().IsInGame())
		{
			_objectToActive = GameObject.FindGameObjectWithTag("OrbContainer");

			for(int i = 0; i < _objectToActive.transform.childCount; i++)
			{
				_objectToActive.transform.GetChild(i).gameObject.SetActive(true);
			}
		}

	}

}
