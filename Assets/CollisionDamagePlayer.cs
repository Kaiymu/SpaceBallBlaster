using UnityEngine;
using System.Collections;

public class CollisionDamagePlayer : MonoBehaviour {

	public int damage;

	private Color _colorPlayer;

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerLife>().setLife(damage);
			_colorPlayer = col.transform.GetComponent<SpriteRenderer>().color = Color.red;
			Debug.Log (_colorPlayer);
			StartCoroutine("Fade");
		}
	}

	IEnumerator Fade() {
		for (float f = 0f; f <= 1; f += 0.1f) {
			Color c = renderer.material.color;
			c.r = f;
			//c.g = -f;
			//c.b = -f;

			renderer.material.color = c;
			yield return new WaitForSeconds(.1f);
		}
	}
}
