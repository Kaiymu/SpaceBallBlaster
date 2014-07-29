using UnityEngine;
using System.Collections;

public class SpikkingBallsSize : MonoBehaviour {

	public enum Size{normalSize, midSize, smallSize};
	public Size sizeBall;

	private Vector3 _scaleBall;

	void Start()
	{
		switch(sizeBall)
		{
			case  Size.normalSize:
				_scaleBall = new Vector3(1f, 1f, 1f);
			break;

			case Size.midSize : 
				_scaleBall = new Vector3(0.75f, 0.75f, 0.75f);
			break;

			case Size.smallSize :
				_scaleBall = new Vector3(0.40f, 0.40f, 0.40f);
			break;
		}

		this.transform.localScale = _scaleBall;
	}
	
}
