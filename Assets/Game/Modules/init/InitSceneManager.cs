namespace Game
{
    public class InitSceneManager : SceneManagerBase
    {
        protected override void Start()
        {
            base.Start();
            SystemManager.Instance.EnterScene(SceneId.Home);
        }

        public override bool HandleBackButtonPress()
        {
            
            BackButtonService.Instace.DefaultBackButtonAction();
            return base.HandleBackButtonPress();
        }
    }
}