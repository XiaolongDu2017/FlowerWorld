using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class HomeSceneManager : SceneManagerBase
    {
        [SerializeField] private GameObject[] m_FlowerStates;
        [SerializeField] private UINormalButton m_BtnGrow, m_BtnWater;
        [SerializeField] private Image m_TimerBar;
        [SerializeField] private Text m_TimerText, m_TextGold;
        [SerializeField] private GameObject m_TimeRoot, m_WaterCam,m_UiRoot;

        private GameData m_GameData;

        private GameObject m_CurProp;

        protected override void Start()
        {
            base.Start();

            m_GameData = GameData.Instance;
            OnStateChangeHander();

            var mainCamera = Camera.main;
            
            mainCamera.transform.localPosition = new Vector3(-0.374f,2.345f,7.159f);
            mainCamera.transform.localEulerAngles = new Vector3(12.3f,130f,0);
            LeanTween.moveLocal(mainCamera.gameObject, new Vector3(-1.367f, 2.172f, -1.144f), 3f);
            LeanTween.rotate(mainCamera.gameObject, new Vector3(19f, -90f, 0f), 3f).setOnComplete(() =>
            {
                m_UiRoot.SetActive(true);
            });


//            if (m_GameData.FlowerState == FlowerState.Empty)
//            {
//                OnClickStore();
//            }
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            EventManager.Instance.addEventListener(EventType.FlowerStateChange, OnStateChangeHander);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            EventManager.Instance.removeEventListener(EventType.FlowerStateChange, OnStateChangeHander);
        }

        private void OnStateChangeHander()
        {
            var state = (int) m_GameData.FlowerState;
            m_TimeRoot.SetActive(m_GameData.FlowerState != FlowerState.Empty && m_GameData.FlowerState != FlowerState.Ripe);

            for (int i = 0; i < m_FlowerStates.Length; i++)
            {
                m_FlowerStates[i].SetActive(state == i);
            }

            m_TextGold.text = "" + m_GameData.Gold;
        }


        public void OnClickStore()
        {
            SystemManager.Instance.PopupManager.ShowPopup("Prefab_Store");
        }

        public void OnClickArrange()
        {
            SystemManager.Instance.EnterScene(SceneId.ArrangeFlower);
        }

        public void Water()
        {
            if (m_GameData.FlowerState == FlowerState.Ripe || m_GameData.FlowerState == FlowerState.Empty) return;

            if (m_GameData.water >= 2)
            {
                return;
            }

            m_GameData.water++;
            m_BtnWater.enabled = false;
            m_WaterCam.SetActive(true);

            m_GameData.NextTime = m_GameData.NextTime.AddSeconds(-10);

            LeanTween.delayedCall(1.1f, () =>
            {
                m_WaterCam.SetActive(false);
                m_BtnWater.enabled = true;

                var state = (int) m_GameData.FlowerState;
                m_CurProp = m_FlowerStates[state];
                var animator = m_CurProp.GetComponent<Animator>();
                if (animator != null)
                    animator.Play("dance");
            });
        }

        public void OnClickGrow()
        {
            if (m_GameData.FlowerState != FlowerState.Ripe) return;

            m_GameData.FlowerState = FlowerState.Empty;
            m_GameData.Gold += 100;
            OnStateChangeHander();
        }

        public override bool HandleBackButtonPress()
        {
            BackButtonService.Instace.DefaultBackButtonAction();
            return false;
        }

        private void Update()
        {
            if (!m_TimeRoot.activeSelf) return;

            var timeSpan = m_GameData.NextTime - DateTime.Now;
            var curVal = 1 - (float) timeSpan.TotalSeconds / GameData.PreStateSec;
            m_TimerBar.fillAmount = Mathf.Clamp01(curVal);
            m_TimerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);


            if (timeSpan.TotalSeconds <= 0)
            {
                var state = m_GameData.FlowerState;
                if (state != FlowerState.Ripe)
                {
                    var newState = (int) state;
                    newState++;
                    m_GameData.FlowerState = (FlowerState) newState;
                    EventManager.Instance.DispatchEvent(EventType.FlowerStateChange);
                }
                else
                {
                    m_TimeRoot.SetActive(false);
                }
            }
        }
    }
}