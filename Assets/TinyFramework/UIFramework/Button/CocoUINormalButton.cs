using System;
using UnityEngine;
using UnityEngine.EventSystems;


namespace CocoPlay
{
    public class CocoUINormalButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        // name
        [SerializeField] protected UIButtonID m_ButtonID;
        [SerializeField] protected string m_ButtonKey;

        public UIButtonID ButtonID
        {
            get { return m_ButtonID; }
            set { m_ButtonID = value; }
        }

        public string ButtonKey
        {
            get { return m_ButtonKey; }
            set { m_ButtonKey = value; }
        }

        #region Press

        // press
        [Header("Press")] public float pressScale = 1.1f;

        private Vector3 m_OriginalScale;

        protected virtual void Start()
        {
            m_OriginalScale = transform.localScale;
        }

        protected int m_UniqueId = int.MaxValue;

        protected virtual void OnButtonPress(bool press)
        {
            Vector3 targetScale = press ? m_OriginalScale * pressScale : m_OriginalScale;
            if (m_UniqueId != int.MaxValue) LeanTween.cancel(gameObject, m_UniqueId);
            m_UniqueId = LeanTween.scale(gameObject, targetScale, 0.15f).setIgnoreTimeScale(true).uniqueId;
        }

        #endregion


        #region Click

        // click
        [Header("Click")] public bool handleClick = true;

        public event Action<CocoUINormalButton> OnClick;

        protected virtual void ButtonClick()
        {
        }

        protected virtual void OnButtonClick()
        {
            if (OnClick != null)
                OnClick(this);

            ButtonClick();
        }

        #endregion


        #region IPointer Down/Up/Click Handler implementation

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (!handleClick)
            {
                return;
            }

            OnButtonPress(true);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (!handleClick)
            {
                return;
            }

            OnButtonPress(false);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!handleClick)
            {
                return;
            }

            AudioManager.instance.PlayAudio("button");
            OnButtonClick();
        }

        #endregion
    }
}