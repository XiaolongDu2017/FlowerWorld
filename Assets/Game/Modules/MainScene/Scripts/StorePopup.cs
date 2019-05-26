using Game;
using UnityEngine;
using UnityEngine.Events;
using EventType = Game.EventType;

public class StorePopup : PopupViewBase
{
    [SerializeField] private Transform m_Content;
    protected override void OnShowFinished()
    {
        base.OnShowFinished();
        for (int i = 0; i < 8; i++)
        {
            var btn = UILoad.InstantiateOrCreate<UINormalButton>("Prefab_StoreItem", m_Content.transform);
            if (btn.targetEvent == null)
                btn.targetEvent = new UnityEvent();
            btn.targetEvent.AddListener(OnClickItem);
        }
    }

    private void OnClickItem()
    {
        GameData.Instance.FlowerState = FlowerState.Seed;
        EventManager.Instance.DispatchEvent(EventType.FlowerStateChange);
        
        ClosePopup();
    }

    public void ClosePopup()
    {
        HidePopup();
    }
}