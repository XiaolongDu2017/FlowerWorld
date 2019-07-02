using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
    public class UINormalButton : ViewBase, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        public string ButtonKey;

        #region Init/clean

        protected override void Start()
        {
            m_OriginalScale = transform.localScale;
            if (m_MainImage == null)
            {
                m_MainImage = GetComponentInChildren<Image>(true);
            }
            m_OriginalSprite = m_MainImage != null ? m_MainImage.sprite : null;
        }

        #endregion


        #region Touch Enable

        protected virtual bool IsTouchEnabled
        {
            get { return SystemManager.Instance.isTouchEnable; }
        }

        #endregion


        #region Press

        // press
        [Header("Press")] [SerializeField] private bool m_UseScale = true;

        [SerializeField] private float m_PressScale = 1.1f;
        private Vector3 m_OriginalScale = Vector3.one;
        [SerializeField] private bool m_UsePressSprite = false;
        [SerializeField] private Sprite m_PressSprite;
        [SerializeField] private Image m_MainImage;
        protected Sprite m_OriginalSprite;


        protected Image MainImage
        {
            get { return m_MainImage; }
        }

        public Camera uiCamera
        {
            get { return m_MainImage.canvas.worldCamera; }
        }

        private int m_UniqueId = int.MaxValue;

        protected virtual void OnButtonPress(bool pRess)
        {
            if (!IsTouchEnabled && pRess)
                return;

            if (pRess)
            {
                //TODO play sound
            }

            if (m_UseScale)
            {
                Vector3 targetScale = pRess ? m_OriginalScale * m_PressScale : m_OriginalScale;
                if (m_UniqueId != int.MaxValue) LeanTween.cancel(gameObject, m_UniqueId);
                m_UniqueId = LeanTween.scale(gameObject, targetScale, 0.15f).setIgnoreTimeScale(true).uniqueId;
            }

            if (m_UsePressSprite)
            {
                SwitchSpriteOnPress(pRess);
            }
        }

        protected virtual void SwitchSpriteOnPress(bool pRess)
        {
            if (m_MainImage == null)
            {
                return;
            }

            m_MainImage.sprite = pRess ? m_PressSprite : m_OriginalSprite;
        }

        #endregion


        #region Click

        // click
        [Header("Click")] public bool handleClick = true;

        public UnityEvent targetEvent;

        protected void OnButtonClick()
        {
            if (!IsTouchEnabled)
                return;

            if (!handleClick)
                return;

            OnClick();

            if (targetEvent != null)
                targetEvent.Invoke();
        }

        protected virtual void OnClick()
        {
            if (!string.IsNullOrEmpty(ButtonKey))
                EventManager.Instance.DispatchEvent(EventType.CommonBtnClick, this);
            Debug.LogError("ButtonKey: "+ ButtonKey);
        }

        #endregion


        #region IPointer Down/Up/Click Handler implementation

        void IPointerDownHandler.OnPointerDown(PointerEventData pEventData)
        {
            OnButtonPress(true);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData pEventData)
        {
            OnButtonPress(false);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData pEventData)
        {
            OnButtonClick();
        }

        #endregion
    }
}