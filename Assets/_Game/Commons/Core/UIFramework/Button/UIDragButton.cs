using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class UIDragButton : UINormalButton, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        protected Vector3 StartPos;
        protected Vector3 StartLocalPos;
        protected bool InDrag = false;
        [SerializeField] bool m_EnableBackAnimation = false;
        [SerializeField] protected Transform DragTrans;

        public Action<UIDragButton> EndAction;
        public Action<UIDragButton> MoveAction;
        public Action<UIDragButton> StartAction;

        #region init

        protected override void Start()
        {
            base.Start();

            if (DragTrans == null) DragTrans = transform;
            StartPos = DragTrans.position;
        }

        #endregion

        #region OnPointer

        protected override void OnButtonPress(bool pRess)
        {
            if (pRess)
            {
                if (InDrag) return;

                StartPos = DragTrans.position;
                StartLocalPos = DragTrans.localPosition;
            }

            base.OnButtonPress(pRess);
        }

        protected override bool IsTouchEnabled
        {
            get
            {
                if (InDrag)
                {
                    return false;
                }
                return base.IsTouchEnabled;
            }
        }

        protected override void OnClick()
        {
            // disable base.OnClick
        }

        #endregion

        #region OnDrag

        public void OnBeginDrag(PointerEventData pEventData)
        {
            OnCcDragStart(pEventData);
        }

        public void OnDrag(PointerEventData pEventData)
        {
            OnCcDragMove(pEventData);
        }

        public void OnEndDrag(PointerEventData pEventData)
        {
            OnCcDragEnd(pEventData);
        }

        protected virtual void OnCcDragStart(PointerEventData pEventData)
        {
            if (InDrag) return;

            InDrag = true;
            OnButtonPress(false);

            if (StartAction != null)
                StartAction(this);
        }

        protected virtual void OnCcDragMove(PointerEventData pEventData)
        {
            if (!InDrag) return;

            DragTrans.position = SystemManager.Instance.SystemCamerm.ScreenToWorldPoint(pEventData.position);
            if (MoveAction != null)
                MoveAction(this);
        }

        protected virtual void OnCcDragEnd(PointerEventData pEventData)
        {
            StopDrag(pEventData);
        }

        protected virtual void StopDrag(PointerEventData pEventData)
        {
            if (!InDrag) return;
            StartCoroutine(MoveBack());
        }

        protected IEnumerator MoveBack()
        {
            bool mainTouchEnable = SystemManager.Instance.isTouchEnable;
            if (mainTouchEnable)
                SystemManager.Instance.isTouchEnable = false;
            if (m_EnableBackAnimation)
            {
                float time = Vector3.Distance(DragTrans.position, StartPos) / 30f;
                LeanTween.moveLocal(DragTrans.gameObject, StartLocalPos, time);
                yield return new WaitForSeconds(time);
            }
            else
            {
                DragTrans.localPosition = StartLocalPos;
            }
            if (mainTouchEnable)
                SystemManager.Instance.isTouchEnable = true;

            OnMoveBackFinish();
        }

        protected virtual void OnMoveBackFinish()
        {
            InDrag = false;
            OnButtonPress(false);
            if (EndAction != null)
                EndAction(this);
        }

        #endregion
    }
}