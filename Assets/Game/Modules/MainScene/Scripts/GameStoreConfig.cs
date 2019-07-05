using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{
    public class GameStoreConfig : MonoBehaviour {

        public static GameStoreConfig Instance {
            get {
                if (_instance == null) {
                    _instance = new GameStoreConfig();
                }
                return _instance;
            }
        }
        private static GameStoreConfig _instance = null;

        public GameStoreConfig() {
            InitData();
        }

        public List<StoreItemData> SeedDatas {
            get {
                return m_seedDatas;
            }
        }
        public List<StoreItemData> FlowerpotDatas
        {
            get
            {
                return m_FlowerpotData;
            }
        }
        private List<StoreItemData> m_seedDatas = null;
        private List<StoreItemData> m_FlowerpotData = null;
        private void InitData() {
            m_seedDatas = new List<StoreItemData>();
            //Photo
            for (int i = 1; i < 4; i++)
            {
                var item = new StoreItemData()
                {
                    m_id = i,
                    storeType = StoreType.Seed,
                    iconPath = "ico_zhongzi_" + i,
                    itemPath = string.Format("UI/icon/photo_{0:D2}", i),// "UI/icon/",
                    cost = 0,
                };
                m_seedDatas.Add(item);
            }

            m_FlowerpotData = new List<StoreItemData>();
            for (int i = 1; i < 4; i++)
            {
                var item = new StoreItemData()
                {
                    m_id = i,
                    storeType = StoreType.Flowerpot,
                    iconPath = "UI/icon_small/icon_small_photo_0" + i,
                    itemPath = string.Format("UI/icon/photo_{0:D2}", i),// "UI/icon/",
                    cost = 0,
                };
                m_FlowerpotData.Add(item);
            }
        }
    }
}
