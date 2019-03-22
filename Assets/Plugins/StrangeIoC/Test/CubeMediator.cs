using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public enum Demo1MediatorEvent
{
    ScoreChange,
    ClickDown
}

public class CubeMediator : Mediator
{
    [Inject ]
    public CubeView cubeView { get; set; }
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }
    // [Inject]不推荐
    // public ScoreModel scoreModel { get; set; }
    public override void OnRegister()
    {
        Debug.Log(cubeView);
        cubeView.Init();
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange,OnScoreChange);
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown,OnClickDown);
        //通过dispatcher发起请求分数的命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange,OnScoreChange);
        dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown,OnClickDown);
    }

    public void OnScoreChange(IEvent evt)
    {
        // cubeView.UpdateScore(scoreModel.Score);
        cubeView.UpdateScore((int)evt.data);

    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
        Debug.Log("OnClickDown");
    }
}