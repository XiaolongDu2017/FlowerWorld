using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Game;

public class GameFlyerDesignItemButton :UINormalButton
{

    #region Init

    [SerializeField]
    private Image m_Icon;
    [SerializeField]
    private GameObject m_Select;

    bool m_IsSelect = false;
    CategoryState m_CurCategoryState = CategoryState.None;
    protected GameFlyerDesignItemData m_FlyerDesignItemData;
    private Vector3 m_OriginalScale;

    public static GameFlyerDesignItemButton Create(string prefabsPath, GameFlyerDesignItemData item, Transform parent, CategoryState categoryState)
    {
        Debug.LogError("prefabsPath: "+ prefabsPath);
        GameFlyerDesignItemButton button = Instantiate(Resources.Load<GameFlyerDesignItemButton>(prefabsPath), parent);
        button.InitInfo(item, categoryState);
        return button;
    }

    protected void InitInfo(GameFlyerDesignItemData item, CategoryState categoryState)
    {
        m_FlyerDesignItemData = item;
        m_CurCategoryState = categoryState;
        this.name = m_FlyerDesignItemData.m_Id; //string.Format ("{0}_{1:D3}", m_CurCategoryName, m_FlyerDesignItemData.m_Index);
        Init();
    }

    protected void Init()
    {
        //CocoSprite.SetSprite(m_Icon, m_FlyerDesignItemData.m_IconPath);
        m_Icon.sprite = Resources.Load<Sprite>(m_FlyerDesignItemData.m_IconPath);
        ChangeStatus();

        //InitStateControl ();
    }
   
    void ChangeStatus()
    {
        m_Select.SetActive(m_IsSelect);
    }
    protected override void OnClick()
    {
        base.OnClick();
        EventManager.Instance.DispatchEvent(Game.EventType.ArrangeButtonClick, this);
    }
    protected override void AddListeners()
    {
        base.AddListeners();
        EventManager.Instance.addEventListener(Game.EventType.ArrangeButtonClick, OnFlyerDesignItemBtnClick);
    }
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        EventManager.Instance.removeEventListener(Game.EventType.ArrangeButtonClick, OnFlyerDesignItemBtnClick);
    }
    private void OnFlyerDesignItemBtnClick(object button) {
        var data = (button as GameFlyerDesignItemButton).FlyerDesignItemData; 
        if (data.m_Id == FlyerDesignItemData.m_Id) {
            m_IsSelect = true;

        }
        else {
            m_IsSelect = false;
        }
        ChangeStatus();
    }
    public GameFlyerDesignItemData FlyerDesignItemData
    {
        get
        {
            return m_FlyerDesignItemData;
        }
    }

    public CategoryState CategoryState
    {
        get
        {
            return m_CurCategoryState;
        }
    }

    #endregion
}
