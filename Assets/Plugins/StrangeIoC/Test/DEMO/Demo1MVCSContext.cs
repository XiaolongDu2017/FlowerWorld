using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.mediation.impl;

public class Demo1MVCSContext : MVCSContext {

    public Demo1MVCSContext(MonoBehaviour view) : base(view)
    {
    }

    protected override void mapBindings()//进行绑定映射
    {
        //model
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        //service
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();//只在整个工程中生成一个
        //command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();
        //mediator(view)
        mediationBinder.Bind<CubeView>().To<CubeMediator>();//完成mediator和view的绑定


//        绑定开始事件一个startcommand(只绑定一次，再触发就解绑了)
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }

}