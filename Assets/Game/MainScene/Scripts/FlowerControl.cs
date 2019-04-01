using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerControl : MonoBehaviour {

	public GameObject[] flowerStates;

	bool isCanShowTime = false;
	public GameObject timeText;
	System.DateTime nextStateDataTime;
	int stageIndex = 0;

	public void InitFlowerData()
	{
		stageIndex = 0;
		foreach (var flower in flowerStates)
		{
			flower.SetActive(false);
		}
		timeText = Instantiate(Resources.Load("TimeText") as GameObject);
		timeText.transform.SetParent(GameObject.Find("Middle").transform);
		timeText.transform.localPosition = new Vector3(0, -340, 0);
		timeText.transform.localScale = Vector3.one;
		flowerStates[0].SetActive(true);

		nextStateDataTime = System.DateTime.Now.AddSeconds(5);
		isCanShowTime = true;
	}


	void Update()
	{
		if (!isCanShowTime)
			return;
		System.TimeSpan pSpan = nextStateDataTime - System.DateTime.Now;
		timeText.GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}:{2:D2}", pSpan.Hours, pSpan.Minutes, pSpan.Seconds);
		if (pSpan.TotalSeconds <= 0)
		{
			stageIndex++;
			SetStageState();

		}
	}

	public void SetStageState()
	{

		for (int i = 0; i < flowerStates.Length; i++)
		{
			if (i == stageIndex)
				flowerStates[i].SetActive(true);
			else
				flowerStates[i].SetActive(false);

		}

		if (stageIndex >= (flowerStates.Length-1))
		{
			isCanShowTime = false;
			timeText.SetActive(false);
			return;
		}


		nextStateDataTime = System.DateTime.Now.AddSeconds(5);
	}

}
