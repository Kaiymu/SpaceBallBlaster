using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPool : MonoBehaviour {
	
	public static ManagerPool Instance { get; private set;}
	
	public GameObject[] arrayOrbs;
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


		_orbs = new List<GameObject>();
		
		for(int i = 0; i < arrayOrbs.Length; i++)
		{
			for(int j = 0; j < spawn; j++)
			{
				GameObject o = Instantiate(arrayOrbs[i]) as GameObject;
				o.SetActive(false);
				_orbs.Add(o);
			}
		}
	}
}
