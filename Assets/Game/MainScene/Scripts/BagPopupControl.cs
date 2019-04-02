using System.Collections;
using System.Collections.Generic;
using CocoPlay;
using UnityEngine;

public class BagPopupControl : MonoBehaviour {

	public CocoUINormalButton[] buttonsObj;

	public CocoUINormalButton[] items;

	GameObject seedParent;

	void Start()
	{
		seedParent = GameObject.Find("Scene");
		foreach (CocoUINormalButton btn in buttonsObj)
		{
			btn.OnClick += OnNormalButtonClick;
		}
		foreach (CocoUINormalButton btn in items)
		{
			btn.OnClick += OnItemButtonClick;
		}
	}


	void OnDestory()
	{
		foreach (CocoUINormalButton btn in buttonsObj)
		{
			btn.OnClick -= OnNormalButtonClick;
		}
		foreach (CocoUINormalButton btn in items)
		{
			btn.OnClick -= OnItemButtonClick;
		}
	}

	private void OnNormalButtonClick(CocoUINormalButton button)
	{
		switch (button.ButtonKey)
		{
			case "BagPopup_Close":
				this.gameObject.SetActive(false);
				break;
		}
	}


	private void OnItemButtonClick(CocoUINormalButton button)
	{
		this.gameObject.SetActive(false);
		GameObject seed = Instantiate(Resources.Load("Flower01") as GameObject);
		seed.transform.SetParent(seedParent.transform);
		seed.transform.position = new Vector3(-2.482f, 1.37f, 0);
		seed.GetComponent<FlowerControl>().InitFlowerData();

	}
}
