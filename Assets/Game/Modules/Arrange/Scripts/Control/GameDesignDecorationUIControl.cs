using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.UI;
using System.IO;


public class GameDesignDecorationUIControl : ViewBase {
    [SerializeField]
    private Image m_BGImg;
    [SerializeField]
    private Image m_FlowerVaseImage;
    [SerializeField]
    private Image m_FlowerVaseMask;
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
        EventManager.Instance.addEventListener(Game.EventType.CommonBtnClick, OnClickCommonButton);
    }
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        EventManager.Instance.removeEventListener(Game.EventType.ArrangeButtonClick, OnItemBtnClick);
        EventManager.Instance.removeEventListener(Game.EventType.CommonBtnClick, OnClickCommonButton);

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
    public void SetFlowerVaseMask(string path)
    {
        if (!m_FlowerVaseMask.gameObject.activeSelf) m_FlowerVaseMask.gameObject.SetActive(true);
        m_FlowerVaseMask.sprite = Resources.Load<Sprite>(path);
        m_FlowerVaseMask.SetNativeSize();
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
                if(button.FlyerDesignItemData.m_Index == 1 || button.FlyerDesignItemData.m_Index == 5) {
                    SetFlowerVaseMask(button.FlyerDesignItemData.m_ItemPath+"_mask");
                }
                else {
                    m_FlowerVaseMask.gameObject.SetActive(false);
                }
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
    private void OnClickCommonButton(object obj) {
        UINormalButton button = obj as UINormalButton;
        switch (button.ButtonKey) {
            case "SavePhoto":
                if (isCanSavePhoto)
                    StartCoroutine(OnClickSavePhoto());
                break;
        }
    }
    private bool isCanSavePhoto = true;
    [SerializeField] Transform m_StartPos;
    [SerializeField] Transform m_EndPos;
    #region SavaImage
    public IEnumerator OnClickSavePhoto() {
        yield return OnSavePhoto();
        yield return AfterSavePhoto();
    }
    public IEnumerator OnSavePhoto()
    {
        m_ShareBtnObj.SetActive(false);
        m_BackBtnObj.SetActive(false);
        GameDesignData.Instance.DetailItems.ForEach((GameDetailItemView item) => {
            item.IsSelected = false;
        });
        if (_TextItem)
            _TextItem.IsSelected = false;
        yield return new WaitForEndOfFrame();
        Vector3 startPos = Camera.main.WorldToScreenPoint(m_StartPos.position);
        Vector3 endPos = Camera.main.WorldToScreenPoint(m_EndPos.position);
        float rectW = endPos.x - startPos.x;
        float rectH = endPos.y - startPos.y;
        //          m_btnDownload.SetActive (false);
        Texture2D texture = UITool.CaptureCameras(new Rect(startPos.x, startPos.y, rectW, rectH),Camera.main);
        //          m_btnDownload.SetActive (true);
        var m_DirectoryPath = Path.Combine(Application.persistentDataPath, "FlyerDesign");
        string fileName = string.Format(ConstName.FlyerDesignPhotoConst,GameDesignData.Instance.GetCurSavePhoto()+1);//"flyerDesign_preview.png";
        string path = Path.Combine(m_DirectoryPath, fileName);

        if (!Directory.Exists(m_DirectoryPath))
        {
            Directory.CreateDirectory(m_DirectoryPath);
        }

        var bytes = texture.EncodeToPNG();
        Debug.LogError(path);
        File.WriteAllBytes(path, bytes);
        GameDesignData.Instance.AddSavePhoto(path);
        Debug.LogError(path + "  rect:" + startPos.x + "  " + startPos.y + "  " + rectW + "  " + rectH);
        Destroy(texture);
        //          if (Application.isEditor){
        //              saveImageSignal.Dispatch (path, (bool isSuc) => {
        //              });
        //          }
        isCanSavePhoto = false;
    }
    [SerializeField]
    private GameObject m_PhotoWriteObj;
    [SerializeField]
    private GameObject m_PhotoObj;
    [SerializeField]
    private GameObject[] m_AfterPhotoEnableObj;
    [SerializeField]
    private GameObject m_ShareBtnObj;
    [SerializeField]
    private GameObject m_BackBtnObj;

    private IEnumerator AfterSavePhoto() {
        //transform.le
        var _count = m_AfterPhotoEnableObj.Length;
        for(int i=0; i < _count; i++) {
            m_AfterPhotoEnableObj[i].SetActive(false);
        }
        LeanTween.scale(m_PhotoObj, Vector3.one*1.2f,0.8f);
        LeanTween.rotateZ(m_PhotoObj, 45f, 0.8f).setOnComplete(()=>
        {
            m_PhotoWriteObj.transform.localEulerAngles = new Vector3(0,90,0);
            LeanTween.rotateY(m_PhotoObj, 90, 0.5f).setOnComplete(()=> {
                m_PhotoObj.SetActive(false);
                m_PhotoWriteObj.SetActive(true);
                LeanTween.rotateY(m_PhotoWriteObj, 0, 0.5f);
            });
        });
        yield return new WaitForSeconds(1.3f);
        m_ShareBtnObj.SetActive(true);
        m_BackBtnObj.SetActive(true);
    }

    #endregion

}
