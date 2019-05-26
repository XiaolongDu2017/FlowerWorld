using UnityEngine;

namespace Game
{
    public class PopupViewBase : ViewBase,IBackButtonListener
    {
        [SerializeField] private GameObject m_ScaleParent;
        [SerializeField] private float m_NormalAniTime = 0.3f;
        [SerializeField] private string m_PopupKey;

        public PopupMaskType MaskType;

        protected override void AddListeners()
        {
            base.AddListeners();
            SubscribeToBackButtonEvent();
        }

        protected override void RemoveListeners()
        {
            UnSubscribeFromBackButtonEvent();
            base.RemoveListeners();
        }

        protected override void Start()
        {
            base.Start();

            Init();
            ShowPopup();
        }

        protected virtual void Init()
        {
        }


        protected virtual void ShowPopup()
        {
            gameObject.SetActive(true);
            if (m_NormalAniTime > 0)
            {
                m_ScaleParent.transform.localScale = Vector3.one * 0.1f;
                LeanTween.scale(m_ScaleParent, Vector3.one, m_NormalAniTime)
                    .setEase(LeanTweenType.easeInOutSine)
                    .setIgnoreTimeScale(true)
                    .setOnComplete(OnShowFinished);
            }
            else
            {
                OnShowFinished();
            }
        }

        protected virtual void OnShowFinished()
        {
        }

        protected virtual void HidePopup()
        {
            if (m_NormalAniTime > 0)
                LeanTween.scale(m_ScaleParent, Vector3.one * 0.1f, m_NormalAniTime)
                    .setEase(LeanTweenType.easeInOutSine)
                    .setIgnoreTimeScale(true)
                    .setOnComplete(OnHideFinished);
            else
            {
                OnHideFinished();
            }
        }

        protected virtual void OnHideFinished()
        {
            if (!string.IsNullOrEmpty(m_PopupKey))
                EventManager.Instance.DispatchEvent(EventType.CommonPopupClose, m_PopupKey);
            SystemManager.Instance.PopupManager.HidePopup(this);
        }
        
        public void SubscribeToBackButtonEvent()
        {
            BackButtonService.Instace.AddListener(this);
        }

        public void UnSubscribeFromBackButtonEvent()
        {
            BackButtonService.Instace.RemoveListener(this);
        }

        public virtual bool HandleBackButtonPress()
        {
            HidePopup();
            return true;
        }
    }
}