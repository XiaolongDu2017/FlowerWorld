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
		InintFlowerData();
	}

	void InintFlowerData()
	{
		if (PlayerPrefs.GetInt("hasFlower") < 1)
		{
			return;
		}
		GameObject seed = Instantiate(Resources.Load("Flower01") as GameObject);
		seed.transform.SetParent(GameObject.Find("Scene").transform);
		seed.transform.position = new Vector3(-2.482f, 1.37f, 0);
		seed.GetComponent<FlowerControl>().InitFlowerState(PlayerPrefs.GetString("flowerGenerateTime"));
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
