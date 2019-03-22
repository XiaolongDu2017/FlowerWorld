using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;

public class ScoreService : IScoreService {
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void RequestScore(string url)
    {
        Debug.Log("RequestScore from url"+url);
        OnrecieveScore();
    }

    public void OnrecieveScore()
    {
        int score = UnityEngine.Random.Range(0, 100);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore,score);

        Debug.Log("OnrecieveScore");
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("updatescore to url"+url+"newscore"+score);
    }
}