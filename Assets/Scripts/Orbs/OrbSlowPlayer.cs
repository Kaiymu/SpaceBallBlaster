using UnityEngine;
using System.Collections;

/************************************************************************************************
* Only on the ice Orb
**  Make the player slows and blink in a blue color.
************************************************************************************************/

public class OrbSlowPlayer : MonoBehaviour {

	public float slowSpeedPlayer = 0.1f;
	public float numberColorBlink;
	public float speedColorBlink;
	private ManagerColor _managerColor;

	void OnEnable()
	{
		_managerColor = ManagerColor.Instance;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "Arrow")
		{
			this.gameObject.SetActive(false);
			col.gameObject.SetActive(false);
		}

		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerMovement>().SlowPlayer(slowSpeedPlayer);
			GameObject player = col.transform.gameObject;
			_managerColor.SlowFade(player, numberColorBlink, speedColorBlink);
		}
	}
}
