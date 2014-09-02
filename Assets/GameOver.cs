using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void Update () 
	{
		if(ManagerArray.Instance.getOrbArray().Count == 0)
			Debug.Log ("GameOver");
	}
}
