using UnityEngine;
using System.Collections;

public class DestroyPassingObjects : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Arrow")
			col.gameObject.SetActive(false);
	}
}
