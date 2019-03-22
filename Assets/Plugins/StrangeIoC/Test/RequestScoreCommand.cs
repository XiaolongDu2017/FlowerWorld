using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine.UI;

public class RequestScoreCommand : EventCommand
{
    [Inject]
    public IScoreService scoreService { get; set; }
    [Inject]
    public ScoreModel scoreModel { get; set; }
    public override void Execute()
    {
//让这个对象不销毁
        Retain();
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore,OnComplete);
        Debug.Log("“requestscoreCommand”");
        scoreService.RequestScore("“http://xxx/xxx//xxx“");
    }

    private void OnComplete(IEvent evt)//IEvent存储的就是参数
    {
        Debug.Log("requestScore OnComplete"+evt.data);
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore,OnComplete);
        scoreModel.Score = (int)evt.data;
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange,evt.data);
        Release();
    }
}