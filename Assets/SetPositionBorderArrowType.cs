using UnityEngine;
using System.Collections;

public class SetPositionBorderArrowType : MonoBehaviour {

	public GameObject player;
	public GameObject[] UIBorder;

	private PlayerShoot _arrowType;
	private int _posArrayArrow;
	

	// Use this for initialization
	void Start () {
		_arrowType = player.GetComponent<PlayerShoot>();
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < UIBorder.Length; i++)
		{
			UIBorder[i].SetActive(false);
			UIBorder[_arrowType.getArrowType()].SetActive(true);
		}
	}
}
