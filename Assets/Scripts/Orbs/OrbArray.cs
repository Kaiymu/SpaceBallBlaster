using UnityEngine;
using System.Collections;

public class OrbArray : MonoBehaviour {

	private ManagerArray _managerArray;

	void OnEnable()
	{
		ManagerArray.Instance.addOrbToArray(this.gameObject);
	}
	

}
