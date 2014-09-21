using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPool : MonoBehaviour {

	private GameObject arrayOrbs;
	public int spawn = 10;

	private List<GameObject> _orbs;

	public List<GameObject> getOrb()
	{
		return _orbs;
	}

	void OnEnable () {
		arrayOrbs = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>().poolOrbs;
		_orbs = new List<GameObject>();
		
		for(int i = 0; i < arrayOrbs.transform.childCount; i++)
		{
			for(int j = 0; j < spawn; j++)
			{
				GameObject o = Instantiate(arrayOrbs.transform.GetChild(i).gameObject) as GameObject;
				o.SetActive(false);
				_orbs.Add(o);
			}
		}
	}
}
