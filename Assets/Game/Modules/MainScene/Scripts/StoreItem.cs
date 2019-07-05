using Game;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : UINormalButton {
    public Action<int> OnClickItemIndex;
    [SerializeField] private Image m_Icon;
    public int dataIndex;
    private StoreItemData data;
    private static string prefabPath = "Prefab_StoreItem";
    public static StoreItem Create(int index,StoreItemData storeItemData,Transform parent)
    {
        StoreItem view = UILoad.InstantiateOrCreate<StoreItem>(prefabPath, parent);
        view.data = storeItemData;
        view.dataIndex = index;
        view.Init();
        Debug.LogError("data.iconPath" + storeItemData.iconPath);
        return view;
    }
    private void Init() {
        Debug.LogError("data.iconPath"+ data.iconPath);
        m_Icon.sprite = Resources.Load<Sprite>(data.iconPath);
        m_Icon.SetNativeSize();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnClick()
    {
        base.OnClick();
        if(OnClickItemIndex != null)
            OnClickItemIndex(dataIndex);
    }
   

}
