using UnityEngine;
using System.Collections;
using CocoPlay;
using UnityEngine.EventSystems;

namespace Game
{
	public class GameDetailsOperateDragButton : UIDragButton
    {
		public GameDetailItemView item;
//		public bool isLimitRect = false;
		[SerializeField]
		bool m_IsScale = false;

		private readonly int MAX_DIS = 100;
		private readonly float OFF_DIS = 50;
		private readonly float MIN_OFF_DIS = 35;
		private readonly float ORIGIN_WH = 70;

		protected override void OnButtonPress (bool press){
			base.OnButtonPress (press);
			if (press) {
				if (item != null)
					item.IsSelected = true;
			}
		}

		private Vector3 m_TouchStartPos;		//落手点
		private Vector3 m_TempPos;
		private Vector3 m_offSet;
		
		private Vector3 m_TargetTempPos;

		protected override void OnCcDragStart(PointerEventData eventData){
			base.OnCcDragStart(eventData);
			
			m_TouchStartPos = eventData.position;
			m_TempPos = UITool.GetUIToScreenPos(DragTrans.position);
			m_offSet = m_TouchStartPos - m_TempPos;
		}

		protected override void OnCcDragMove (UnityEngine.EventSystems.PointerEventData eventData)
		{
			if (!InDrag) return;
			
//			if (!isLimitRect) {
				m_TargetTempPos= UITool.GetScreenToUIWorldPos(eventData.position - new Vector2(m_offSet.x,m_offSet.y));
				DragTrans.position = m_TargetTempPos;
			if (!m_IsScale){
				//item.UpdatePos ();
			}
			else{
				item.UpdateScale ();
                //CocoAudio.PlaySound(GameAudioID.sizing);
            }
//				float dis = OFF_DIS * this.GetComponent<RectTransform> ().sizeDelta.x / ORIGIN_WH;
//				dis = Mathf.Clamp (dis, MIN_OFF_DIS, dis);
//			} else {
//				Vector3 worldPos = CCTool.GetScreenToUIWorldPos (eventData.position);
//				Vector3 localPos = this.transform.parent.InverseTransformPoint (worldPos);
//
//				if (localPos.sqrMagnitude > MAX_DIS * MAX_DIS) {
//					localPos = localPos.normalized * MAX_DIS;
//				}
//				transform.localPosition = localPos;
//			}

		}

		protected override void OnCcDragEnd (UnityEngine.EventSystems.PointerEventData eventData){
			InDrag = false;
		}
	}
}