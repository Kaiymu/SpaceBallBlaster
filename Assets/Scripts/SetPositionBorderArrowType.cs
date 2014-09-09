using UnityEngine;
using System.Collections;

public class SetPositionBorderArrowType : MonoBehaviour {

	public GameObject player;
	public GameObject[] UIBorder;

	private PlayerShoot _arrowType;
	private int _posArrayArrow;
	

	void OnEnable()
	{
		PlayerShoot.isChangingArrow += ChangingArrow;
	}
	
	void OnDisable()
	{
		PlayerShoot.isChangingArrow -= ChangingArrow;
	}

	void Start () {
		_arrowType = player.GetComponent<PlayerShoot>();

		for(int i = 0; i < UIBorder.Length; i++)
		{
			UIBorder[i].SetActive(false);
			UIBorder[0].SetActive(true);
		}
	}

	void ChangingArrow () {

		for(int i = 0; i < UIBorder.Length; i++)
		{
			UIBorder[i].SetActive(false);
			UIBorder[_arrowType.getArrowType()].SetActive(true);
		}
	}
}
