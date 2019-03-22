using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class CubeView : View
{[Inject]
    public IEventDispatcher dispatcher { get; set; }

    private Text scoreText;
//慎用start和awake。不能覆盖掉父类的方法
    /// <summary>
    /// 做初始化mediator
    /// </summary>
    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    protected override void Start()
    {
        base.Start();
    }

    public void OnMouseDown()
    {
        //加分
        Debug.Log("OnMouseDown");
        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}