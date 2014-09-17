using UnityEngine;
using System.Collections;

/************************************************************************************************
* On every orb
**  Make the orb adding itself to the array, to know how much orb i have on the game.
************************************************************************************************/

public class OrbArray : MonoBehaviour {

	void OnEnable()
	{
		ManagerArray.Instance.addOrbToArray(this.gameObject);
	}
}
