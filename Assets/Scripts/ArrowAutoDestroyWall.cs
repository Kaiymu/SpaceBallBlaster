using UnityEngine;
using System.Collections;

public class ArrowAutoDestroyWall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Wall")
			this.gameObject.SetActive(false);
	}
}
