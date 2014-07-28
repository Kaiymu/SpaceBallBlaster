using UnityEngine;
using System.Collections;

public class BlinkColor : MonoBehaviour {
	
	private Color _blink;
	// To optimize, too bad.
	public void StartBlink(GameObject _objectToFade, float _numberFade, float _speedFade)
	{
		StartCoroutine(Fade(_objectToFade, _numberFade, _speedFade));
	}

	IEnumerator Fade(GameObject _objectToFade, float _numberFade, float _speedFade)
	{
		_blink = _objectToFade.transform.GetComponent<SpriteRenderer>().color;
		for(float i = 0; i < _numberFade; i++)
		{
			for(float f = 0f; f <= 1; f += _speedFade) {
				_blink.r = f;
			}
			
			for(float f = 1f; f >= 0; f-= _speedFade)
			{
				_blink.g = f;
				_blink.b = f;
				_objectToFade.transform.GetComponent<SpriteRenderer>().color = _blink;
				yield return new WaitForSeconds(.1f);
			}
			
			for(float f = 0f; f <= 1; f += _speedFade) {;
				_blink.g = f;
				_blink.b = f;
				_objectToFade.transform.GetComponent<SpriteRenderer>().color = _blink;
				yield return new WaitForSeconds(.1f);
			}
		}
	}
}
