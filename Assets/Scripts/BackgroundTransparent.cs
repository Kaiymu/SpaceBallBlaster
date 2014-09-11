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
		// When the level is complete, or the player as lost.
		ManagerMenu.OnEndLevel += FadeInBackground;
		// When the player pause the game.
		ManagerMenu.OnPauseGame += FadeInBackground;
		// When the player unpause the game.
		ManagerMenu.OnUnPauseGame += UnfadeBackground;
	}

	void OnDisable()
	{
		ManagerMenu.OnEndLevel -= FadeInBackground;
		ManagerMenu.OnPauseGame -= FadeInBackground;
		ManagerMenu.OnUnPauseGame -= UnfadeBackground;
	}

	void FadeInBackground()
	{
		this.gameObject.renderer.material.color = endColorBackground;
	}

	void UnfadeBackground()
	{
		this.gameObject.renderer.material.color = startColorBackground;
	}
}
