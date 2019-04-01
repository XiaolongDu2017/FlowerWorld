using System.Collections;
using System.Collections.Generic;
using CocoPlay;
using UnityEngine;

public class MainGameSceneManager : MonoBehaviour {

	public CocoUINormalButton[] buttonsObj;
	public GameObject bagUI;


	// Use this for initialization
	void Start () {
		foreach (CocoUINormalButton btn in buttonsObj)
		{
			btn.OnClick += OnNormalButtonClick;
		}
	}


	void OnDestory()
	{
		foreach (CocoUINormalButton btn in buttonsObj)
		{
			btn.OnClick -= OnNormalButtonClick;
		}
	}

	private void OnNormalButtonClick(CocoUINormalButton button)
	{
		switch (button.ButtonKey)
		{
			case "bag":
				bagUI.SetActive(true);
				break;
		}
	}

}
