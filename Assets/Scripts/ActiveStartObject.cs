using UnityEngine;
using System.Collections;

public class ActiveStartObject : MonoBehaviour {

	public GameObject[] objectToActive;

	void Start () {

		for(int i = 0; i < objectToActive.Length; i++)
		{
			objectToActive[i].SetActive(true);
		}
	}

}
