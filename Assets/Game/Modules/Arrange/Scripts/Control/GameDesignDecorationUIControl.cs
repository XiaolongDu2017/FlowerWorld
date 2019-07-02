using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.UI;


public class GameDesignDecorationUIControl : ViewBase {
    [SerializeField]
    private Image m_BGImg;
    [SerializeField]
    private Image m_FlowerVaseImage;
    [SerializeField]
    private Image m_FlowerImage;
    [SerializeField]
    private Transform m_TextParent;
    [SerializeField]
    private Transform m_DetailsParent;
    protected override void AddListeners()
    {
        base.AddListeners();
        EventManager.Instance.addEventListener(Game.EventType.ArrangeButtonClick, OnItemBtnClick);
    }
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        EventManager.Instance.removeEventListener(Game.EventType.ArrangeButtonClick, OnItemBtnClick);

    }
   

    public void SetBGImage(string path)
    {
        m_BGImg.sprite = Resources.Load<Sprite>(path);
        m_BGImg.SetNativeSize();
    }

    public void SetFlowerVaseImage(string path)
    {
        if (!m_FlowerVaseImage.gameObject.activeSelf) m_FlowerVaseImage.gameObject.SetActive(true);
        m_FlowerVaseImage.sprite = Resources.Load<Sprite>(path);
        m_FlowerVaseImage.SetNativeSize();


    }
    public void SetFlowerImage(string path)
    {
        if (!m_FlowerImage.gameObject.activeSelf) m_FlowerImage.gameObject.SetActive(true);
        m_FlowerImage.sprite = Resources.Load<Sprite>(path);
        m_FlowerImage.SetNativeSize();

    }
    private GameTextItemView _TextItem;
    public void SetTextImage(string path)
    {
        if (!m_TextParent.gameObject.activeSelf) m_TextParent.gameObject.SetActive(true);
        //m_TextParent.sprite = Resources.Load<Sprite>(path);
        //m_TextParent.SetNativeSize();
        if (_TextItem == null) {
            _TextItem = GameTextItemView.Create(path, m_TextParent, TextPrefabsPath);
            _TextItem.transform.localPosition = GetRandomStickerPostion();
        }
        else {
            _TextItem.Init(path);
        }
    }
    private const string PrefabsPath = "Prefab/GameDetailOperateItem";
    private const string TextPrefabsPath = "Prefab/GameTextItem";
    public void AddDetails(string path)
    {
        GameDetailItemView itemView = GameDetailItemView.Create(path, m_DetailsParent,PrefabsPath);
        itemView.transform.localPosition = GetRandomStickerPostion();
        itemView.UpdateScale();
    }

    private Vector3 GetRandomStickerPostion()
    {
        float x, y;
        if (Random.value > 0.5f)
            x = Random.Range(80f, 150f);
        else
            x = Random.Range(-150f, -80f);

        y = Random.Range(-210f, 210f);

        return new Vector3(x, y, 0f);
    }
    private void OnItemBtnClick(object obj)
    {
        GameFlyerDesignItemButton button = obj as GameFlyerDesignItemButton;
        switch (button.CategoryState)
        {
            case CategoryState.BG:
                SetBGImage(button.FlyerDesignItemData.m_ItemPath);
                break;

            case CategoryState.FlowerVase:
                SetFlowerVaseImage(button.FlyerDesignItemData.m_ItemPath);
                break;

            case CategoryState.Flower:
                SetFlowerImage(button.FlyerDesignItemData.m_ItemPath);
                break;

            case CategoryState.Text:
                SetTextImage(button.FlyerDesignItemData.m_ItemPath);
                break;
            case CategoryState.Detail:
                AddDetails(button.FlyerDesignItemData.m_ItemPath);
                break;
        }
    }

}
