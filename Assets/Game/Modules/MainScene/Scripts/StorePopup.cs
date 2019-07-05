using Game;
using UnityEngine;
using UnityEngine.Events;
using EventType = Game.EventType;
using System.Collections.Generic;

public class StorePopup : PopupViewBase
{
    [SerializeField] private Transform m_Content;

    private StoreType curStoryType;
    private List<StoreItemData> m_ItemDatas = new List<StoreItemData>();
    private string prefabPath;
    public static StorePopup Create(string itemPrefabPath,StoreType storeType) {
        StorePopup view = (StorePopup)SystemManager.Instance.PopupManager.ShowPopup("Prefab_Store");
        view.curStoryType = storeType;
        view.prefabPath = itemPrefabPath;
        view.InitData();
        return view;
    }

    protected override void Init()
    {
        base.Init();
    }
    public void InitData() { 
        if(curStoryType == StoreType.Seed) {
            m_ItemDatas = GameStoreConfig.Instance.SeedDatas;
        }
        else {
            Debug.LogError(GameStoreConfig.Instance.FlowerpotDatas);
            m_ItemDatas = GameStoreConfig.Instance.FlowerpotDatas;
        }
    }
    protected override void OnShowFinished()
    {
        base.OnShowFinished();
        int count = m_ItemDatas.Count;
        for (int i = 0; i < count; i++)
        {
            //var btn = UILoad.InstantiateOrCreate<UINormalButton>(prefabPath, m_Content.transform);
            //if (btn.targetEvent == null)
            //    btn.targetEvent = new UnityEvent();
            //btn.targetEvent.AddListener(OnClickItem);
            var btn = StoreItem.Create(i,m_ItemDatas[i],m_Content.transform);
            btn.OnClickItemIndex = OnClickItem;
        }
    }

    private void OnClickItem(int dataIndex)
    {
        GameData.Instance.Gold -= m_ItemDatas[dataIndex].cost;

        if (m_ItemDatas[dataIndex].storeType == StoreType.Flowerpot)
        {
            GameData.Instance.FlowerpotIndex = dataIndex;
            EventManager.Instance.DispatchEvent(EventType.FlowerpotStateChange);
        }
        else if (m_ItemDatas[dataIndex].storeType == StoreType.Seed)
        {
            GameData.Instance.FlowerState = FlowerState.Seed;
            GameData.Instance.FlowerSeedIndex = dataIndex;
            EventManager.Instance.DispatchEvent(EventType.FlowerStateChange);
        }

        ClosePopup();
    }

    public void ClosePopup()
    {
        HidePopup();
    }
}