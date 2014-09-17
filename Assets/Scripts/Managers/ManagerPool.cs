using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPool : MonoBehaviour {
	
	public static ManagerPool Instance { get; private set;}
	
	private GameObject arrayOrbs;
	public int spawn = 10;

	private List<GameObject> _orbs;

	public List<GameObject> getOrb()
	{
		return _orbs;
	}

	void Awake()
	{
		if(Instance != null && Instance != this)
			Destroy(gameObject);
		
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
	
	void Start () {

		if(!this.GetComponent<isOnGame>().IsInGame())
		{
			arrayOrbs = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>().arrayOrbsStart;
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
}
