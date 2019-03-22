/// The only change in StartCommand is that we extend Command, not EventCommand

using System;
using UnityEngine;
using strange.extensions.command.impl;

public class StartCommand : Command
{
    public override void Execute()
    {
        Debug.LogError("StartCommand");
//            _gameStateModel.StartGame();
//
//            //game controlelrs
//            GameObject pGameControllers = UnityEngine.GameObject.Instantiate (Resources.Load ("CocoMainController", typeof(GameObject))) as GameObject;
//            pGameControllers.transform.parent = GameApplication.Instance.Transform;
//
//            BackButtonService pBackButtonService = GameObject.FindObjectOfType <BackButtonService> ();
//            injectionBinder.Bind <BackButtonService> ().ToValue (pBackButtonService).CrossContext ();
    }
}

