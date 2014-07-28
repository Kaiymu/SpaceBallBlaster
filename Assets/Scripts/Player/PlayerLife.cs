using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	private int _life = 5;
	
	public int getLife()
	{
		return _life;
	}

	public void setLife(int life)
	{
		if(_life < 0)
			_life = 0;
		else
			_life -= life;
	}

}