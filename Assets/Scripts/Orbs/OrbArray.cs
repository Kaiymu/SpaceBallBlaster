using UnityEngine;
using System.Collections;

public class OrbArray : MonoBehaviour {

	private ManagerArray _managerArray;

	void Start()
	{
		ManagerArray.Instance.addOrbToArray(this.gameObject);
	}

}
