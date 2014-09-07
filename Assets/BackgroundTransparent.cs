using UnityEngine;
using System.Collections;

public class BackgroundTransparent : MonoBehaviour {

	public Color startColorBackground;
	public Color endColorBackground;

	void Awake () {
		this.gameObject.renderer.material.color = startColorBackground;
	}

	void OnEnable()
	{
		GameOver.OnEndLevel += FadeInBackground;
	}

	void OnDisable()
	{
		GameOver.OnEndLevel -= FadeInBackground;
	}

	void FadeInBackground()
	{
		this.gameObject.renderer.material.color = endColorBackground;
	}
}
