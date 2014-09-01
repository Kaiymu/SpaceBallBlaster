using UnityEngine;
using System.Collections;

public class OrbSize : MonoBehaviour {

	public enum Size{normalSize, midSize, smallSize};
	public Size sizeOrb;

	private Vector3 _scaleOrb;

	void Start()
	{
		switch(sizeOrb)
		{
			case Size.normalSize:
				_scaleOrb = new Vector3(1f, 1f, 1f);
			break;

			case Size.midSize : 
				_scaleOrb = new Vector3(0.75f, 0.75f, 0.75f);
			break;

			case Size.smallSize :
				_scaleOrb = new Vector3(0.40f, 0.40f, 0.40f);
			break;
		}

		this.transform.localScale = _scaleOrb;
	}
	
}
