using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.EventSystems;

public class GameTextDragButton : UIDragButton {

    [SerializeField]
    private GameTextItemView item;
    protected override void OnButtonPress(bool press)
    {
        base.OnButtonPress(press);
        if (press)
        {
            if (item != null)
                item.IsSelected = true;
        }
    }
   

    private Vector3 m_TouchStartPos;        //落手点
    private Vector3 m_TempPos;
    private Vector3 m_offSet;

    private Vector3 m_TargetTempPos;
    protected override void OnCcDragStart(PointerEventData eventData)
    {
        base.OnCcDragStart(eventData);

        m_TouchStartPos = eventData.position;
        m_TempPos = UITool.GetUIToScreenPos(DragTrans.position);
        m_offSet = m_TouchStartPos - m_TempPos;
    }
    protected override void OnCcDragMove(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (!InDrag) return;

        //          if (!isLimitRect) {
        DragTrans.position = UITool.GetScreenToUIWorldPos(eventData.position - new Vector2(m_offSet.x, m_offSet.y));

        if (MoveAction != null)
            MoveAction(this);

    }

    protected override void OnCcDragEnd(UnityEngine.EventSystems.PointerEventData eventData)
    {
        InDrag = false;
    }
}
