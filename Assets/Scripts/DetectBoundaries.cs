using UnityEngine;
using System.Collections;

public class DetectBoundaries : MonoBehaviour {

	public GameObject TopWall, BottomWall, LeftWall, RightWall;
	// Use this for initialization
	void Start () {

		// Up
		TopWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane) );

		// Bottom
		BottomWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane) );

		// Left
		LeftWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane) );

		// Right
		RightWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane) );

	}

}
