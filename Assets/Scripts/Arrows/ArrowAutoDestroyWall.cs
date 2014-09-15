using UnityEngine;
using System.Collections;

public class ArrowAutoDestroyWall : MonoBehaviour {

	// A script to attach on each arrow, put back the arrow in the object pool when it's collide with it. 
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Wall")
			this.gameObject.SetActive(false);
	}
}
