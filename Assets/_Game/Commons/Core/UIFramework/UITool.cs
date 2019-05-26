using UnityEngine;

namespace Game
{
    public static class UITool
    {
        #region Transform
        #region Position

        public static void Set_X(this Transform pTrans, float pX)
        {
            Vector3 pos = pTrans.position;
            pos.x = pX;
            pTrans.position = pos;
        }

        public static void Set_Y(this Transform pTrans, float pY)
        {
            Vector3 pos = pTrans.position;
            pos.y = pY;
            pTrans.position = pos;
        }

        public static void Set_Z(this Transform pTrans, float pZ)
        {
            Vector3 pos = pTrans.position;
            pos.z = pZ;
            pTrans.position = pos;
        }

        public static void SetLocal_X(this Transform pTrans, float pX)
        {
            Vector3 pos = pTrans.localPosition;
            pos.x = pX;
            pTrans.localPosition = pos;
        }

        public static void SetLocal_Y(this Transform pTrans, float pY)
        {
            Vector3 pos = pTrans.localPosition;
            pos.y = pY;
            pTrans.localPosition = pos;
        }

        public static void SetLocal_Z(this Transform pTrans, float pZ)
        {
            Vector3 pos = pTrans.localPosition;
            pos.z = pZ;
            pTrans.localPosition = pos;
        }

        public static void AddLocal(this Transform pTrans, Vector3 pOffset)
        {
            pTrans.localPosition += pOffset;
        }

        public static void AddLocal_X(this Transform pTrans, float pX)
        {
            pTrans.localPosition += new Vector3(pX, 0, 0);
        }

        public static void AddLocal_Y(this Transform pTrans, float pY)
        {
            pTrans.localPosition += new Vector3(0, pY, 0);
        }

        public static void AddLocal_Z(this Transform pTrans, float pZ)
        {
            pTrans.localPosition += new Vector3(0, 0, pZ);
        }

        public static void Add_X(this Transform pTrans, float pX)
        {
            pTrans.position += new Vector3(pX, 0, 0);
        }

        public static void Add_Y(this Transform pTrans, float pY)
        {
            pTrans.position += new Vector3(0, pY, 0);
        }

        public static void Add_Z(this Transform pTrans, float pZ)
        {
            pTrans.position += new Vector3(0, 0, pZ);
        }

        public static void Add(this Transform pTrans, Vector3 pAdd)
        {
            pTrans.position += pAdd;
        }

        #endregion

        public static void RemoveAllChildren(this Transform pTransform)
        {
            for (int i = pTransform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(pTransform.GetChild(i).gameObject);
            }
        }

        public static void SetZero(this Transform pTarget)
        {
            pTarget.localEulerAngles = Vector3.zero;
            pTarget.localPosition = Vector3.zero;
            pTarget.localScale = Vector3.one;
        }

        #endregion
    }
}