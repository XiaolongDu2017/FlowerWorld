using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class HomeSceneManager : SceneManagerBase
    {
        [SerializeField] private GameObject[] m_FlowerStates;
        [SerializeField] private GameObject[] m_FlowerpotModels;//花盆模型
        [SerializeField] private UINormalButton m_BtnGrow, m_BtnWater;
        [SerializeField] private Image m_TimerBar;
        [SerializeField] private Text m_TimerText, m_TextGold;
        [SerializeField] private GameObject m_TimeRoot, m_WaterCam,m_UiRoot;

        private GameData m_GameData;

        private GameObject m_CurProp;

		public Text uiText;
        public string PrefabsPath = "Prefab_StoreItem";
        protected override void Start()
        {
            base.Start();
			uiText.text = "+" + addVaule;
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
	        EventManager.Instance.addEventListener(EventType.FlowerpotStateChange, OnFlowerpotStateChangeHander);
            EventManager.Instance.addEventListener(EventType.FlowerStateChange, OnStateChangeHander);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
	        EventManager.Instance.removeEventListener(EventType.FlowerpotStateChange, OnFlowerpotStateChangeHander);
            EventManager.Instance.removeEventListener(EventType.FlowerStateChange, OnStateChangeHander);
        }

	    
	    #region Flowerpot
	    
	    //花盆选择
	    private void OnFlowerpotStateChangeHander()
	    {
		    var index = (int) m_GameData.FlowerpotIndex;
		    for (var i = 0; i < m_FlowerpotModels.Length; i++)
			    GenerateFlowerpot(m_FlowerpotModels[i], index == i);
	    }

	    private void GenerateFlowerpot(GameObject obj, bool isActive)
	    {
		    if (!isActive)
		    {
			    obj.SetActive(false);
			    return;
		    }

		    //粒子效果
		    var particle = Instantiate(Resources.Load<ParticleSystem>("flowerpotParticle"), obj.transform);
		    particle.transform.SetParent(obj.transform.parent, true);
		    Destroy(particle.gameObject, 5.0f);
		    LeanTween.delayedCall(1.0f, () => { obj.SetActive(true); });
	    }

	    #endregion
	    

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

		public void OnClickFlower()
		{
			if (m_GameData.FlowerState == FlowerState.Ripe)
			{
				m_GameData.FlowerState = FlowerState.Empty;
				for (int i = 0; i < m_FlowerStates.Length; i++)
				{
					m_FlowerStates[i].SetActive(false);
				}
			}
			else
			{
				
				AddGold();
			}
		}
        public void OnClickFlowerpot()
        {
            if (m_GameData.FlowerState == FlowerState.Empty || m_GameData.FlowerState == FlowerState.None)
            {
                Debug.LogError("OnClickFlowerpot");
                StorePopup.Create(PrefabsPath, StoreType.Flowerpot);
            }
           
        }
        public void OnClickSeed()
        {
            if (m_GameData.FlowerState == FlowerState.Empty || m_GameData.FlowerState == FlowerState.None)
            {
                Debug.LogError("OnClickSeed");
                StorePopup.Create(PrefabsPath, StoreType.Seed);
            }

        }
        public override bool HandleBackButtonPress()
        {
            BackButtonService.Instace.DefaultBackButtonAction();
            return false;
        }


        private void Update()
        {
			if (!uiText.gameObject.activeSelf || uiText.gameObject.GetComponent<CanvasGroup>().alpha <= 0)
			{
				if (m_GameData.FlowerState == FlowerState.Empty)
					return;
				//Debug.LogError("22");
				uiText.gameObject.SetActive(true);
				uiText.gameObject.GetComponent<CanvasGroup>().alpha = 1;
				uiText.transform.localPosition = new Vector3(36f, -350f, 0);
				LeanTween.moveLocalY(uiText.gameObject, 94, 1f);
				LeanTween.alphaCanvas(uiText.gameObject.GetComponent<CanvasGroup>(), 0, 1f).setOnComplete(() => { 
					 m_GameData.NextTime = m_GameData.NextTime.AddSeconds(addVaule*-1);
				});
			}

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


		private float intervalTime = 1;
		public int addVaule = 5;
		private void AddGold()
		{
			if (m_GameData.FlowerState == FlowerState.Empty)
				return;
			if (m_GameData.FlowerState == FlowerState.Ripe)
				return;
			GameObject tempText = Instantiate(uiText.gameObject) as GameObject;
			tempText.transform.SetParent(uiText.transform.parent);
			tempText.transform.localScale = Vector3.one;
			tempText.transform.localPosition = new Vector3(36f, -350f, 0);
			tempText.gameObject.GetComponent<CanvasGroup>().alpha = 1;
			tempText.gameObject.SetActive(true);
			LeanTween.moveLocalY(tempText.gameObject, 94, 1f);
			LeanTween.alphaCanvas(tempText.gameObject.GetComponent<CanvasGroup>(), 0, 1f).setOnComplete(() => {
				m_GameData.NextTime = m_GameData.NextTime.AddSeconds(addVaule * -1);
				Destroy(tempText);
			});

		}
    }
}