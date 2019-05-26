using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public enum PopupMaskType
    {
        Masked,
        NoMask
    }

    public enum AddPopupType
    {
        Override,
        Add
    }

    public class PopupManager : ViewBase
    {
        [SerializeField] private GameObject m_Mask;

        private readonly List<PopupViewBase> m_CurrenPopups = new List<PopupViewBase>();

        public PopupViewBase ShowPopup(string pPath, PopupMaskType pMaskType = PopupMaskType.Masked,
            AddPopupType pAddPopupType = AddPopupType.Add)
        {
            m_Mask.SetActive(pMaskType == PopupMaskType.Masked);

            if (pAddPopupType == AddPopupType.Override)
                m_CurrenPopups.ForEach(HidePopup);
            else
                m_Mask.transform.SetAsLastSibling();

            PopupViewBase viewBase = UILoad.InstantiateOrCreate<PopupViewBase>(pPath, m_Mask.transform.parent);
            m_CurrenPopups.Add(viewBase);
            viewBase.MaskType = pMaskType;
            return viewBase;
        }

        public void HidePopup(PopupViewBase pPanel)
        {
            m_CurrenPopups.Remove(pPanel);
            Destroy(pPanel.gameObject);
            if (m_CurrenPopups.Count <= 0)
                m_Mask.SetActive(false);
            else
            {
                var view = m_CurrenPopups[m_CurrenPopups.Count - 1];
                view.transform.SetAsLastSibling();
                m_Mask.SetActive(view.MaskType == PopupMaskType.Masked);
            }
        }

        public bool isShowingPopup
        {
            get { return m_CurrenPopups.Count > 0; }
        }
    }
}