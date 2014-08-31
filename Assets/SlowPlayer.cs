using UnityEngine;
using System.Collections;

public class SlowPlayer : MonoBehaviour {

	public float slowSpeedPlayer = 0.1f;
	public float numberColorBlink;
	public float speedColorBlink;
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerMovement>().SlowPlayer(slowSpeedPlayer);
			GameObject player = col.transform.gameObject;
			ManagerColor.Instance.SlowFade(player, numberColorBlink, speedColorBlink);
		}
	}
}
