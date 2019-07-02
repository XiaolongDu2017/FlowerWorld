using System;
using UnityEngine;

namespace Game
{
    public class GameData
    {
        public const int PreStateSec = 300;
        
        private static GameData m_Instance;

        public int water = 0;
        
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


        public static GameData Instance
        {
            get { return m_Instance ?? (m_Instance = new GameData()); }
        }

        public GameData()
        {
        }
    }
}