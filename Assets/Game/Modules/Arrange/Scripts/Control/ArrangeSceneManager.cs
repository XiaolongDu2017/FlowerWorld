using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
            InitUI();
        }

        public void CategorySelect(int pVal)
        {
            for (int i = 0; i < m_CategoryBtns.Length; i++)
            {
                if (i == pVal) continue;
                m_CategoryBtns[i].IsSelected = false;
                //Debug.LogError(pVal);
            }
            InitItems(GameDesignData.Instance.FlyerDesignCategoryDatas[pVal]);
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

      

        private void InitUI() {
            InitItems(GameDesignData.Instance.FlyerDesignCategoryDatas[0]);
        }
        [SerializeField]
        ScrollRect m_ItemScroll;
        List<GameFlyerDesignItemButton> m_ButtonList = new List<GameFlyerDesignItemButton>();
        void InitItems(GameFlyerDesignCategoryData data)
        {

            //List<Pair<GameFlyerDesignItemData, GLDStateItemData>> itemDataList = flyerDesignData.GetFlyerDesignItemDatas(data, saveDataModule.MapSceneData.SelectTheme);
            foreach (Transform child in m_ItemScroll.content)
            {
                Destroy(child.gameObject);
            }
            List<GameFlyerDesignItemData> itemDataList = GameDesignData.Instance.GetFlyerDesignItemDatas(data);
            //string categoryKey = "flydesign_" + data.m_CategoryName;
            m_ButtonList.Clear();
            if (itemDataList != null)
            {
                for (int i = 0; i < itemDataList.Count; i++)
                {
                    GameFlyerDesignItemData t_ItemHolder = itemDataList[i];
                    GameFlyerDesignItemButton itemBtn = GameFlyerDesignItemButton.Create(data.m_ItemPrefabsPath, t_ItemHolder, m_ItemScroll.content, data.m_CategoryState);
                   
                    m_ButtonList.Add(itemBtn);
                }
                EventManager.Instance.DispatchEvent(EventType.ArrangeButtonClick, m_ButtonList[0]);
            }

        }

       
    }
}