using UnityEngine;
using System.Collections;

public class SpikkedArray : MonoBehaviour {

	private ManagerArray _managerArray;

	void Start()
	{
		ManagerArray.Instance.addSpikkedToArray(this.gameObject);
	}

}
