
using UnityEngine;

namespace Game
{
    public class GameData
    {
        private static GameData m_Instance;

        private FlowerState m_FlowerState = FlowerState.None;

        public FlowerState FlowerState
        {
            set
            {
                m_FlowerState = value;
                PlayerPrefs.SetInt("FlowerState", (int) m_FlowerState);
            }
            get
            {
                if (m_FlowerState == FlowerState.None)
                {
                    m_FlowerState = (FlowerState)PlayerPrefs.GetInt("FlowerState", 0);
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