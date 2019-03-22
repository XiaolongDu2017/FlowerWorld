using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace CocoPlay
{
    public class CocoUIDragButton : CocoUINormalButton, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        protected Vector3 m_StartPos;
        protected Vector3 m_StartLocalPos;
        protected bool m_InDrag = false;
        [SerializeField] bool m_EnableBackAnimation = false;
        [SerializeField] protected Transform m_DragTrans;

        #region init

        protected override void Start()
        {
            base.Start();
            if (m_DragTrans == null) m_DragTrans = transform;
            m_StartPos = m_DragTrans.position;
        }

        #endregion

        #region OnPointer

        protected override void OnButtonPress(bool press)
        {
            if (press)
            {
                if (m_InDrag) return;

                m_StartPos = m_DragTrans.position;
                m_StartLocalPos = m_DragTrans.localPosition;
            }

            base.OnButtonPress(press);
        }

        protected override void OnButtonClick()
        {
            base.OnButtonClick();
        }

        #endregion

        #region OnDrag

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnCCDragStart(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnCCDragMove(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnCCDragEnd(eventData);
        }

        protected virtual void OnCCDragStart(PointerEventData eventData)
        {
            if (m_InDrag) return;

            m_InDrag = true;
            OnButtonPress(false);
        }

        protected virtual void OnCCDragMove(PointerEventData eventData)
        {
            if (!m_InDrag) return;

            m_DragTrans.position = CCTool.GetScreenToUIWorldPos(eventData.position);
        }

        protected virtual void OnCCDragEnd(PointerEventData eventData)
        {
            StopDrag(eventData);
        }

        protected virtual void StopDrag(PointerEventData eventData)
        {
            if (!m_InDrag) return;

            StartCoroutine(IMoveBack());
        }

        protected IEnumerator IMoveBack()
        {
            if (m_EnableBackAnimation)
            {
                float time = Vector3.Distance(m_DragTrans.position, m_StartPos) / 30f;
                LeanTween.moveLocal(m_DragTrans.gameObject, m_StartLocalPos, time);
                yield return new WaitForSeconds(time);
            }
            else
            {
                m_DragTrans.localPosition = m_StartLocalPos;
            }

            OnMoveBackFinish();
        }

        protected virtual void OnMoveBackFinish()
        {
            m_InDrag = false;
            OnButtonPress(false);
        }

        #endregion
    }
}