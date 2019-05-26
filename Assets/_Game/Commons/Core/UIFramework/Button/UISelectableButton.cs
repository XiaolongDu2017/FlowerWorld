using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Selectable Button
    /// 可选择的按钮，有选中和没有选中两种状态
    /// </summary>
    public class UISelectableButton : UINormalButton
    {
        #region Init/Clean

        public Action<UISelectableButton> ChangeAction;

        protected override void Start()
        {
            base.Start();
            IsSelected = m_IsSelected;
            UpdateUi();
        }

        #endregion


        #region Select

        [Header("Select")] [SerializeField] private bool m_IsSelected = false;

        [SerializeField] private GameObject m_SelectGo = null;

        [SerializeField] private bool m_UseSelectSprite;
        [SerializeField] private Sprite m_SelectedSprite;

        [SerializeField] private bool m_AutoChange = false;
        [SerializeField] private bool m_IsGroup = false;

        public bool IsSelected
        {
            get { return m_IsSelected; }
            set
            {
                if (m_IsSelected == value)
                    return;

                m_IsSelected = value;
                UpdateUi();
            }
        }

        private void UpdateUi()
        {
            if (m_SelectGo != null)
                m_SelectGo.SetActive(m_IsSelected);

            if (ChangeAction != null)
                ChangeAction(this);

            if (m_UseSelectSprite)
                MainImage.sprite = m_IsSelected ? m_SelectedSprite : m_OriginalSprite;
        }

        protected override void OnClick()
        {
//            base.OnClick();
            if (m_AutoChange)
            {
                if (m_IsGroup)
                    IsSelected = true;
                else
                    IsSelected = !IsSelected;
            }
        }

        #endregion
    }
}