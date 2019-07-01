using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameFlyerDesignCategoryData
{
    public CategoryState m_CategoryState;

    public string m_IconNormalPath;
    public string m_IconSelectPath;

    public string m_ItemPrefabsPath;
    public GridInfo m_ItemGridInfo;

}
public struct GridInfo
{
    public RectOffset padding;
    public Vector2 cellSize;
    public Vector2 spacing;
}
public class GameFlyerDesignItemData
{
    public string m_Id;
    public string m_IconPath;
    public string m_ItemPath;
}
public enum CategoryState { 
    None = 0,
    BG = 1,
    FlowerVase = 2,
    Flower = 3,
    Text = 4,
    Detail = 5, 
}

