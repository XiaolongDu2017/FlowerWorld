using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.mediation.impl;
using UnityEngine;


public class GameMVCSContext : MVCSContext {

    public GameMVCSContext(MonoBehaviour view) : base(view)
    {
        
    }

    protected override void mapBindings()//进行绑定映射
    {
//        绑定开始事件一个startcommand(只绑定一次，再触发就解绑了)
        commandBinder.Bind(ContextEvent.START).To<GameStartCommand>().Once();
    }

}