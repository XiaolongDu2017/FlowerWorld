using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.UI;
public class GameTextItemView : ViewBase
{
    [SerializeField] GameObject btnClose;
    [SerializeField] GameObject Frame;
    [SerializeField] Image m_ContentImage;

    public static GameTextItemView Create(string path, Transform parent, string PrefabsPath)
    {
        GameTextItemView view = Instantiate(Resources.Load<GameTextItemView>(PrefabsPath), parent);
        view.Init(path);
        return view;
    }
    #region init
    public void Init(string path) {
        m_ContentImage.sprite = Resources.Load<Sprite>(path);
        IsSelected = true;
        ChangeStatus();
    }

    #endregion

    private bool m_IsSelected = false;
    public bool IsSelected
    {
        set
        {
            if (m_IsSelected != value)
            {
                m_IsSelected = value;
                ChangeStatus();
            }
        }
        get { return m_IsSelected; }
    }
    private void ChangeStatus()
    {
        btnClose.SetActive(IsSelected);
        //Frame.SetActive(IsSelected);

    }
    protected override void AddListeners()
    {
        base.AddListeners();
        //uiButtonClickSignal.AddListener(OnUIButtonClick);
        EventManager.Instance.addEventListener(Game.EventType.CommonBtnClick, OnUIButtonClick);
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        EventManager.Instance.removeEventListener(Game.EventType.CommonBtnClick, OnUIButtonClick);
    }
    protected void OnUIButtonClick(object obj)
    {
        if (!IsSelected)
            return;
        var button = obj as UINormalButton;
        if (button.ButtonKey == "Design_BG")
        {
            IsSelected = false;
        }
        else if (button.ButtonKey == "btnOperateClose")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
