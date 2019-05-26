using UnityEngine;

namespace Game
{
    public class HomeSceneManager : SceneManagerBase
    {

        [SerializeField] private GameObject[] m_FlowerStates;
        [SerializeField] private UINormalButton m_BtnGrow;

        private GameData m_GameData;

        protected override void Start()
        {
            base.Start();

            m_GameData = GameData.Instance;
            
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            EventManager.Instance.addEventListener(EventType.FlowerStateChange,OnStateChangeHander);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            EventManager.Instance.removeEventListener(EventType.FlowerStateChange,OnStateChangeHander);
        }

        private void OnStateChangeHander()
        {
            var state = (int)m_GameData.FlowerState;
            for (int i = 0; i < m_FlowerStates.Length; i++)
            {
                m_FlowerStates[i].SetActive(state == i);
            }
        }


        public void OnClickStore()
        {
            SystemManager.Instance.PopupManager.ShowPopup("Prefab_Store");
        }

        public void OnClickArrange()
        {
            SystemManager.Instance.EnterScene(SceneId.ArrangeFlower);
        }
        
        public void OnClickGrow()
        {
            m_BtnGrow.enabled = false;
            
            if(m_GameData.FlowerState == FlowerState.Ripe) return;
            if(m_GameData.FlowerState == FlowerState.Empty) return;

            int state = (int) m_GameData.FlowerState;
            state++;
            m_GameData.FlowerState = (FlowerState) state;
            EventManager.Instance.DispatchEvent(EventType.FlowerStateChange);
            LeanTween.delayedCall(1, () => { m_BtnGrow.enabled = true;});
        }

        public override bool HandleBackButtonPress()
        {
            BackButtonService.Instace.DefaultBackButtonAction();
            return false;
        }
    }
}