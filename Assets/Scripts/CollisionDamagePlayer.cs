using UnityEngine;
using System.Collections;

public class CollisionDamagePlayer : MonoBehaviour {

	public int damage;
	public float numberColorBlink;
	public float speedColorBlink;

	public GameObject blinkColor;

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerLife>().setLife(damage);
			GameObject player = col.transform.gameObject;
			blinkColor.GetComponent<BlinkColor>().StartBlink(player, numberColorBlink, speedColorBlink);
		}
	}
}
