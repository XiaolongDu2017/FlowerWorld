using UnityEngine;

#if UNITY_EDITOR

#endif

namespace Game
{
    [ExecuteInEditMode]
    public class UIAnchor : MonoBehaviour
    {
        public enum AnchorPos
        {
            None = 0,

            TopLeft = 1,
            Top = 2,
            TopRight = 3,

            MiddleLeft = 4,
            Middle = 5,
            MiddleRight = 6,

            BottomLeft = 7,
            Bottom = 8,
            BottomRight = 9,
        }

        [SerializeField] public AnchorPos anchorPos = AnchorPos.Middle;

        private AnchorPos m_AnchorPos = AnchorPos.None;

        void Update()
        {
            if (m_AnchorPos == anchorPos)
                return;
            m_AnchorPos = anchorPos;
            UpdateAnchor(anchorPos);
        }

        void UpdateAnchor(AnchorPos pAnchorPos)
        {
            RectTransform trans = GetComponent<RectTransform>();
            if (trans == null)
            {
                return;
            }

            Vector2 pos = new Vector2(0.5f, 0.5f);

            switch (pAnchorPos)
            {
                case AnchorPos.TopLeft:
                case AnchorPos.MiddleLeft:
                case AnchorPos.BottomLeft:
                    pos.x = 0f;
                    break;

                case AnchorPos.TopRight:
                case AnchorPos.MiddleRight:
                case AnchorPos.BottomRight:
                    pos.x = 1f;
                    break;
            }
            switch (pAnchorPos)
            {
                case AnchorPos.TopLeft:
                case AnchorPos.Top:
                case AnchorPos.TopRight:
                    pos.y = 1f;
                    break;

                case AnchorPos.BottomLeft:
                case AnchorPos.Bottom:
                case AnchorPos.BottomRight:
                    pos.y = 0f;
                    break;
            }

            trans.anchorMin = pos;
            trans.anchorMax = pos;
            trans.sizeDelta = Vector2.zero;
            trans.name = "Anchor_" + pAnchorPos;
        }
    }
}