using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	public float speed = 0f;
	// Update is called once per frame
	void Update () {
		speed -= 0.01f;
		Vector2 velocity = new Vector2(speed, 0);

		this.transform.position = velocity;
	}
}
