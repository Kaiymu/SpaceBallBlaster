using UnityEngine;
using System.Collections;

public class DestroyPassingObjects : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "ShootedBalls")
			col.gameObject.SetActive(false);
	}
}
