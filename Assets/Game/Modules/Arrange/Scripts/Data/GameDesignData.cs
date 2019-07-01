using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDesignData {
    public static GameDesignData Instance {
        get {
            if (_instance == null)
                _instance = new GameDesignData();
            return _instance;
        }
    }
    private static GameDesignData _instance;

    public GameDesignData() {
        InitCategoryData();
        InitItemData();
    }
    private Dictionary<CategoryState, List<GameFlyerDesignItemData>> m_AllDesignItemDataDic;
    private List<GameFlyerDesignCategoryData> m_FlyerDesignCategorys = null;
    public List<GameFlyerDesignCategoryData> FlyerDesignCategoryDatas {
        get {
            return m_FlyerDesignCategorys;
        }
    }
    private List<GameDetailItemView> m_DetailItems = new List<GameDetailItemView>();
    public List<GameDetailItemView> DetailItems
    {
        get
        {
            return m_DetailItems;
        }
    }
    private void InitCategoryData()
    {
        m_FlyerDesignCategorys = new List<GameFlyerDesignCategoryData>();

        GameFlyerDesignCategoryData categoryData = new GameFlyerDesignCategoryData()
        {
            m_CategoryState = CategoryState.BG,
            m_IconNormalPath = "Category/ico_bg",
            m_IconSelectPath = "Category/ico_bg_xz",
            m_ItemPrefabsPath = "Prefab/Flower",
            m_ItemGridInfo = GetGridInfo("FlyerDesign_BG"),
        };
        m_FlyerDesignCategorys.Add(categoryData);

        GameFlyerDesignCategoryData categoryData1 = new GameFlyerDesignCategoryData()
        {
            m_CategoryState = CategoryState.FlowerVase,
            m_IconNormalPath = "Category/ico_overlay",
            m_IconSelectPath = "Category/ico_overlay_xz",
            m_ItemPrefabsPath = "Prefab/Flower",
            m_ItemGridInfo = GetGridInfo("FlyerDesign_Overlay"),
        };
        m_FlyerDesignCategorys.Add(categoryData1);

        GameFlyerDesignCategoryData categoryData2 = new GameFlyerDesignCategoryData()
        {
            m_CategoryState = CategoryState.Flower,
            m_IconNormalPath = "Category/ico_text",
            m_IconSelectPath = "Category/ico_text_xz",
            m_ItemPrefabsPath = "Prefab/Flower",
            m_ItemGridInfo = GetGridInfo("FlyerDesign_Text"),
        };
        m_FlyerDesignCategorys.Add(categoryData2);

        GameFlyerDesignCategoryData categoryData3 = new GameFlyerDesignCategoryData()
        {
            m_CategoryState = CategoryState.Text,
            m_IconNormalPath = "Category/ico_sticke",
            m_IconSelectPath = "Category/ico_sticke_xz",
            m_ItemPrefabsPath = "Prefab/Flower",
            m_ItemGridInfo = GetGridInfo("FlyerDesign_Details"),
        };
        m_FlyerDesignCategorys.Add(categoryData3);
        GameFlyerDesignCategoryData categoryData4 = new GameFlyerDesignCategoryData()
        {
            m_CategoryState = CategoryState.Detail,
            m_IconNormalPath = "Category/ico_sticke",
            m_IconSelectPath = "Category/ico_sticke_xz",
            m_ItemPrefabsPath = "Prefab/Flower",
            m_ItemGridInfo = GetGridInfo("FlyerDesign_Details"),
        };
        m_FlyerDesignCategorys.Add(categoryData4);
    }

    private GridInfo GetGridInfo(string categoryName)
    {
        GridInfo info = new GridInfo();
        info.padding = new RectOffset(0, 0, 36, 20);
        info.spacing = new Vector2(30, 55);
        info.cellSize = new Vector2(186f, 185f);
        //if (categoryName == "FlyerDesign_Dance")
        //{
        //    info.cellSize = new Vector2(186f, 185f);
        //}
        //else
        //{
        //    info.cellSize = new Vector2(186f, 200f);
        //}

        return info;
    }
    private void InitItemData() {
        m_AllDesignItemDataDic = new Dictionary<CategoryState,List<GameFlyerDesignItemData>>();
        var pair = new List<GameFlyerDesignItemData>();
        //Photo
        for(int i = 1; i< 6; i++) {
            var item = new GameFlyerDesignItemData()
            {
                m_Id = "BG_" + i,
                m_IconPath = "UI/icon_small/icon_small_photo_0" + i,
                m_ItemPath = string.Format("UI/icon/photo_{0:D2}",i),// "UI/icon/",
            };
            pair.Add(item);
        }
        m_AllDesignItemDataDic.Add(CategoryState.BG,pair);
         pair = new List<GameFlyerDesignItemData>();
        //FlowerOvase
        for (int i = 1; i < 6; i++)
        {
            var item = new GameFlyerDesignItemData()
            {
                m_Id = "huaping_" + i,
                m_IconPath = "UI/icon_small/icon_small_huaping_00" + i,
                m_ItemPath = string.Format("UI/icon/huaping_{0:D3}", i),
            };
            pair.Add(item);
        }
        m_AllDesignItemDataDic.Add(CategoryState.FlowerVase, pair);
        pair = new List<GameFlyerDesignItemData>();
        //Flower
        for (int i = 1; i < 6; i++)
        {
            var item = new GameFlyerDesignItemData()
            {
                m_Id = "Flower_" + i,
                m_IconPath = "UI/icon_small/icon_small_flower_carnation_00" + i,
                m_ItemPath = string.Format("UI/icon/flower_carnation_{0:D3}", i),
            };
            pair.Add(item);
        }
        m_AllDesignItemDataDic.Add(CategoryState.Flower, pair);

        pair = new List<GameFlyerDesignItemData>();
        //Text
        for (int i = 1; i < 6; i++)
        {
            var item = new GameFlyerDesignItemData()
            {
                m_Id = "Text_" + i,
                m_IconPath = "UI/icon_small/icon_small_text_0" + i,
                m_ItemPath = string.Format("UI/icon/text_{0:D2}", i),
            };
            pair.Add(item);
        }
        m_AllDesignItemDataDic.Add(CategoryState.Text, pair);

        pair = new List<GameFlyerDesignItemData>();
        //Skiker
        for (int i = 1; i < 6; i++)
        {
            var item = new GameFlyerDesignItemData()
            {
                m_Id = "Skiker_" + i,
                m_IconPath = string.Format("UI/icon_small/icon_small_sticker_{0:D2}", i),//"UI/icon_small_sticker_10" + i,
                m_ItemPath = string.Format("UI/icon/sticker_{0:D2}", i),
            };
            Debug.LogError("item.m_IconPath: "+item.m_IconPath);
            pair.Add(item);
        }
        m_AllDesignItemDataDic.Add(CategoryState.Detail, pair);
    }
    public List<GameFlyerDesignItemData> GetFlyerDesignItemDatas(GameFlyerDesignCategoryData categoryData) {
        //int count 
        if (m_AllDesignItemDataDic.ContainsKey(categoryData.m_CategoryState)) {
            return m_AllDesignItemDataDic[categoryData.m_CategoryState];
        }
        return null;
    }

    
}
