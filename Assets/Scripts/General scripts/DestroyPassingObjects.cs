using UnityEngine;
using System.Collections;

public class DestroyPassingObjects : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log (col.transform.name);
		Destroy(col.gameObject);
	}
}
