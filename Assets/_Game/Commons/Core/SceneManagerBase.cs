using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Game
{
    public class SceneManagerBase : ViewBase,IBackButtonListener
    {
        private IBackButtonListener _backButtonListenerImplementation;

        protected override void Awake()
        {
            base.Awake();
            var current = Loom.Current;
            var systemManager = SystemManager.Instance;

            this.OnRigister();
        }

        protected virtual void OnRigister()
        {
            SubscribeToBackButtonEvent();
        }

        protected virtual void UnRigister()
        {
            UnSubscribeFromBackButtonEvent();
        }

        protected virtual void OnApplicationQuit()
        {
            
        }

        protected virtual void EnterScene(SceneId pSceneId)
        {
           SystemManager.Instance.EnterScene(pSceneId);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.UnRigister();
        }

        public void SubscribeToBackButtonEvent()
        {
            BackButtonService.Instace.AddListener(this);
        }

        public void UnSubscribeFromBackButtonEvent()
        {
            BackButtonService.Instace.RemoveListener(this);
        }

        public virtual bool HandleBackButtonPress()
        {
            return false;
        }
    }
}