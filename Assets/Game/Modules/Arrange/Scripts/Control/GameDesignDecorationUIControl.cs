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
    private Image m_TextImage;
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
    public void SetTextImage(string path)
    {
        if (!m_TextImage.gameObject.activeSelf) m_TextImage.gameObject.SetActive(true);
        m_TextImage.sprite = Resources.Load<Sprite>(path);
        m_TextImage.SetNativeSize();

    }

    public void AddDetails(string path)
    {
        GameDetailItemView itemView = GameDetailItemView.Create(path, m_DetailsParent);
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
