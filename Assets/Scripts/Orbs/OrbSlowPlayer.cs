using UnityEngine;
using System.Collections;

public class OrbSlowPlayer : MonoBehaviour {

	public float slowSpeedPlayer = 0.1f;
	public float numberColorBlink;
	public float speedColorBlink;
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "ShootedBalls")
			col.gameObject.SetActive(false);

		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerMovement>().SlowPlayer(slowSpeedPlayer);
			GameObject player = col.transform.gameObject;
			ManagerColor.Instance.SlowFade(player, numberColorBlink, speedColorBlink);
		}
	}
}
