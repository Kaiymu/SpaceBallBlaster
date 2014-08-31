using UnityEngine;
using System.Collections;

public class ManagerColor : MonoBehaviour {
	
	private Color _blink;

	public static ManagerColor Instance { get; private set;}

	void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		
		Instance = this;
		
		DontDestroyOnLoad(gameObject);
	}

	// To optimize, too bad.
	public void StartBlink(GameObject _objectToFade, float _numberFade, float _speedFade)
	{
		StartCoroutine(FadeRed(_objectToFade, _numberFade, _speedFade));
	}

	IEnumerator FadeRed(GameObject _objectToFade, float _numberFade, float _speedFade)
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

	public void SlowFade(GameObject _objectToColor, float _numberFade, float _speedFade)
	{
		StartCoroutine(FadeBlue(_objectToColor, _numberFade, _speedFade));
	}

	IEnumerator FadeBlue(GameObject _objectToFade, float _numberFade, float _speedFade)
	{
		_blink = _objectToFade.transform.GetComponent<SpriteRenderer>().color;
		for(float i = 0; i < _numberFade; i++)
		{
			for(float f = 0f; f <= 1; f += _speedFade) {
				_blink.b = f;
			}
			
			for(float f = 1f; f >= 0; f-= _speedFade)
			{
				_blink.g = f;
				_blink.r = f;
				_objectToFade.transform.GetComponent<SpriteRenderer>().color = _blink;
				yield return new WaitForSeconds(.1f);
			}
			
			for(float f = 0f; f <= 1; f += _speedFade) {;
				_blink.g = f;
				_blink.r = f;
				_objectToFade.transform.GetComponent<SpriteRenderer>().color = _blink;
				yield return new WaitForSeconds(.1f);
			}
		}
	}

}
