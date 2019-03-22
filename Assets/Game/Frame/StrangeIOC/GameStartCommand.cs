
using UnityEngine;
using strange.extensions.command.impl;

public class GameStartCommand : Command
{
    public override void Execute()
    {
        Debug.LogError("StartCommand");
        
    }
}
