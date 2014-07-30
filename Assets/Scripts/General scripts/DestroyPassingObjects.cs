using UnityEngine;
using System.Collections;

public class DestroyPassingObjects : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy(col.gameObject);
	}
}
