using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class SystemManager : ViewBase
    {
        [SerializeField] public Camera SystemCamerm;

        public bool isTouchEnable = true;

        protected override void Awake()
        {
            base.Awake();
            PopupManager = GetComponent<PopupManager>();
            TipManager = GetComponent<TipManager>();
        }

        private static SystemManager m_SystemManager;

        public static SystemManager Instance
        {
            get
            {
                if (m_SystemManager != null) return m_SystemManager;
                m_SystemManager = UILoad.InstantiateOrCreate<SystemManager>("System");
                DontDestroyOnLoad(m_SystemManager);
                return m_SystemManager;
            }
        }

        public PopupManager PopupManager { get; private set; }
        public TipManager TipManager { get; private set; }


        public void EnterScene(SceneId pSceneId)
        {
            SceneManager.LoadScene((int)pSceneId);
        }


        private void OnApplicationQuit()
        {
        }
    }
}