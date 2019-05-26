using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    /// <summary>
    /// 简单的Tip manager
    /// </summary>
    public class TipManager : ViewBase
    {
        [SerializeField] private Text m_TipText;
        [SerializeField] private GameObject m_TipRoot;

        protected override void Awake()
        {
            base.Awake();
            m_TipRoot.SetActive(false);
        }

        public void ShowTip(string pMsg, float pTime = 3)
        {
            LeanTween.cancel(m_TipRoot);
            m_TipText.text = pMsg;
            m_TipRoot.gameObject.SetActive(true);
            LeanTween.delayedCall(m_TipRoot.gameObject, pTime, () => { m_TipRoot.gameObject.SetActive(false); });
        }

        public void ShowError(string pMsg, float pTime = 5)
        {
            ShowTip(pMsg,pTime);
        }
    }
}