using UnityEngine;
using System.Collections;

public class TimeShootedBar : MonoBehaviour {


	public GameObject player;

	private UISlider _UITimeShooted;
	private float _lastShot;

	void Start () {
		_UITimeShooted = this.gameObject.GetComponent<UISlider>();
		_lastShot      = player.GetComponent<PlayerShoot>().getLastShot();
	}

	void Update()
	{
		//Debug.Log (_lastShot);
	}
}
