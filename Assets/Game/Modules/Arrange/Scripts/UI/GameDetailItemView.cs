using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.UI;

public class GameDetailItemView : ViewBase {

    //private const string PrefabsPath = "Prefab/GameDetailOperateItem";
    #region Init

    [SerializeField]
    private Image m_ContentImage;
    [SerializeField]
    private GameObject btnScale, btnClose, Frame;
    [SerializeField]
    private bool m_IsCanScale = true;

    public static GameDetailItemView Create(string path, Transform parent,string PrefabsPath)
    {
        GameDetailItemView view = Instantiate(Resources.Load<GameDetailItemView>(PrefabsPath), parent);
        view.init(path);
        return view;
    }
    RectTransform m_FrameRectTrans;
    RectTransform m_ContentRectTrans;
    private void init(string path)
    {
        m_ContentImage.sprite = Resources.Load<Sprite>(path);
        IsSelected = true;
        m_FrameRectTrans = Frame.GetComponent<RectTransform>();
        m_ContentRectTrans = m_ContentImage.GetComponent<RectTransform>();
        ChangeStatus();
        GameDesignData.Instance.DetailItems.Add(this);
    }

    private void ChangeStatus()
    {
        btnScale.SetActive(IsSelected);
        btnClose.SetActive(IsSelected);
        Frame.SetActive(IsSelected);

        if (IsSelected)
        {
            transform.SetAsLastSibling();
            GameDesignData.Instance.DetailItems.ForEach((GameDetailItemView item) => {
                if (item.gameObject != null && item.gameObject != this.gameObject)
                    item.IsSelected = false;
            });
        }
    }

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
    public void ChangeIcon(string path) { 
    
    }

    #endregion


    #region Listeners

    protected override void AddListeners()
    {
        base.AddListeners();
        //uiButtonClickSignal.AddListener(OnUIButtonClick);
        EventManager.Instance.addEventListener(Game.EventType.CommonBtnClick,OnUIButtonClick);
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
            GameDesignData.Instance.DetailItems.Remove(this);
            GameObject.Destroy(gameObject);
        }
    }

    #endregion

   
    public void UpdateScale()
    {
        Vector3 scalePos = btnScale.transform.localPosition;
        Debug.LogError("scalePos.magnitude: "+ scalePos.magnitude);
        if (m_IsCanScale) {
            float len = scalePos.magnitude / 1.414f*2;

            Vector3 size = new Vector2(len, len);
            m_FrameRectTrans.SetSize(size);
            m_ContentRectTrans.SetSize(size);
            btnClose.transform.localPosition = new Vector3(-scalePos.x, -scalePos.y, 0);
        }

        float angleZ = VectorAngle(new Vector2(50, -50), new Vector2(scalePos.x, scalePos.y));
        m_ContentImage.transform.localEulerAngles = new Vector3(0, 0, -angleZ);
        Frame.transform.localEulerAngles = new Vector3(0, 0, -angleZ);
        btnClose.transform.localEulerAngles = new Vector3(0, 0, -angleZ);
        btnScale.transform.localEulerAngles = new Vector3(0, 0, -angleZ);

    }
    float VectorAngle(Vector2 from, Vector2 to)
    {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? -angle : angle;
    }
}
