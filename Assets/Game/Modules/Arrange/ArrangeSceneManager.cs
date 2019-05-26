using UnityEngine;

namespace Game
{
    public class ArrangeSceneManager : SceneManagerBase
    {
        [SerializeField] private UISelectableButton[] m_CategoryBtns;


        private GameData m_GameData;

        protected override void Start()
        {
            base.Start();

            m_GameData = GameData.Instance;
        }

        public void CategorySelect(int pVal)
        {
            for (int i = 0; i < m_CategoryBtns.Length; i++)
            {
                if (i == pVal) continue;
                m_CategoryBtns[i].IsSelected = false;
            }
        }


        public void OnClickBack()
        {
            SystemManager.Instance.EnterScene(SceneId.Home);
        }

        public override bool HandleBackButtonPress()
        {
            BackButtonService.Instace.DefaultBackButtonAction();
            return false;
        }
    }
}