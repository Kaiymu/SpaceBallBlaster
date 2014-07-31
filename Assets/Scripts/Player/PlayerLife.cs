using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {
	
	private int _life;

	void Start()
	{
		_life = ManagerDifficulty.Instance.getPlayerLife();
	}
	
	public int getLife()
	{
		return _life;
	}
	
	public void setLife(int life)
	{
		if(_life <= 0)
			_life = 0;
		else
			_life += life;
	}
}