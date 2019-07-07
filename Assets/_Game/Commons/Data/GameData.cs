using System;
using UnityEngine;

namespace Game
{
    public class GameData
    {
        public const int PreStateSec = 300;
        
        private static GameData m_Instance;

        public int water = 0;
        
        public int fertilizer = 0;
        
        public DateTime NextTime;

        public int Gold
        {
            set { PlayerPrefs.SetInt("Gold",  value); }
            get { return PlayerPrefs.GetInt("Gold", 100); }
        }

        private FlowerState m_FlowerState = FlowerState.None;

        public FlowerState FlowerState
        {
            set
            {
                m_FlowerState = value;
                if (m_FlowerState != FlowerState.Empty || m_FlowerState != FlowerState.None)
                {
                    NextTime = DateTime.Now.AddSeconds(PreStateSec);
                    water = 0;
                    fertilizer = 0;
                }

                PlayerPrefs.SetInt("FlowerState", (int) m_FlowerState);
            }
            get
            {
                if (m_FlowerState == FlowerState.None)
                {
                    m_FlowerState = (FlowerState) PlayerPrefs.GetInt("FlowerState", 0);
                }

                return m_FlowerState;
            }
        }


        #region Flowerpot

        //花盆种类索引
        public int FlowerpotIndex
        {
            get { return PlayerPrefs.GetInt("FlowerpotIndex", -1); }
            set { PlayerPrefs.SetInt("FlowerpotIndex", value); }
        }
        
        //花种种类索引
        public int FlowerSeedIndex
        {
            get { return PlayerPrefs.GetInt("FlowerSeedIndex", -1); }
            set { PlayerPrefs.SetInt("FlowerSeedIndex", value); }
        }

        #endregion

        public static GameData Instance
        {
            get { return m_Instance ?? (m_Instance = new GameData()); }
        }

        public GameData()
        {
        }
    }
}