using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UICounter : ViewBase
    {
        [SerializeField] private UINormalButton m_BtnAdd, m_BtnDec;
        [SerializeField] private Text m_TextCount;
        [SerializeField] private int m_Cur, m_Min, m_Max;

        public void SetValue(int pCur, int pMin, int pMax)
        {
            this.m_Cur = pCur;
            this.m_Min = pMin;
            this.m_Max = pMax;

            ChangeValue();
        }

        protected override void Start()
        {
            base.Start();
            ChangeValue();
        }

        public void Add()
        {
            m_Cur++;
            ChangeValue();
        }

        public void Dec()
        {
            m_Cur--;
            ChangeValue();
        }

        public int Current
        {
            get { return m_Cur; }
        }

        private void ChangeValue()
        {
            m_Cur = Mathf.Clamp(m_Cur, m_Min, m_Max);
            m_BtnAdd.handleClick = m_Cur < m_Max;
            m_BtnDec.handleClick = m_Cur > m_Min;

            m_TextCount.text = m_Cur.ToString();
        }
    }
}